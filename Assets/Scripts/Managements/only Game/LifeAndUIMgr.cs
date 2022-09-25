using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeAndUIMgr : MonoBehaviour
{
    [Header("対応するライフのイメージを挿入")]
    public Image LifeBase;
    public Image LifeRed;
    public Image LifeGreen;

    [Header("赤ゲージが減少するスピード倍率")]
    public float redGaugeMoveSpeed;

    [Header("プレイヤが参照されていない場合はエネミーを自動的に設定")]
    public PlayerLifeMgr playerLifeMgr;
    //参照するエネミー
    [HideInInspector]
    public EnemyBase ebase;
    //以下確認用に保管する参照元
    [HideInInspector]
    public EnemyBase saveEBase;

    private float saveLifeNow;

    private void Start()
    {
        //現在のライフを保存
        if (playerLifeMgr)
        {
            saveLifeNow = playerLifeMgr.GetLifeNow();
        }
        else if(ebase)
        {
            saveLifeNow = ebase.GetLifeNow();
        }
        
    }

    private void Update()
    {
        if (playerLifeMgr)
        {
            PlayerLifeUI();
        }
        else if (ebase)
        {
            EnemyLifeUI();
        }
    }

    private void PlayerLifeUI()
    {
        //現在の体力からゲージの減少量を計算する
        float lifeMoveSizeW = 1.0f / playerLifeMgr.GetLifeMax() * playerLifeMgr.GetLifeNow();

        //緑ゲージのサイズを変更
        LifeGreen.transform.localScale = new Vector3(lifeMoveSizeW, 1, 1);

        //もし赤ゲージが緑ゲージより大きかった場合
        if (LifeRed.transform.localScale.x >= LifeGreen.transform.localScale.x)
        {
            if (playerLifeMgr.GetLifeNow() <= 0)
            {
                //赤ゲージのサイズを減少
                //体力が０以下の場合は通常速度
                LifeRed.transform.localScale -= new Vector3((float)(saveLifeNow - playerLifeMgr.GetLifeNow()) / (float)playerLifeMgr.GetLifeMax() * Time.deltaTime, 0, 0);
            }
            else
            {
                //赤ゲージのサイズを減少
                //ダメージ量が違っていても、赤ゲージの見える時間は等しくなる
                LifeRed.transform.localScale -= new Vector3((float)(saveLifeNow - playerLifeMgr.GetLifeNow()) / (float)playerLifeMgr.GetLifeMax() * Time.deltaTime * redGaugeMoveSpeed, 0, 0);
            }
        }
        else
        {
            //赤ゲージと緑ゲージのサイズを等しくする
            LifeRed.transform.localScale = LifeGreen.transform.localScale;
            //現在のライフを保存
            saveLifeNow = playerLifeMgr.GetLifeNow();
        }

        

    }

    private void EnemyLifeUI()
    {
        //現在の体力からゲージの減少量を計算する
        float lifeMoveSizeW = 1.0f / ebase.GetLifeMax() * ebase.GetLifeNow(); ;

        //緑ゲージのサイズを変更
        LifeGreen.transform.localScale = new Vector3(lifeMoveSizeW, 1, 1);

        //以下、赤ゲージをゆっくり減少させる処理/////////////////////////////////////////////////

        //前回の処理とEnemyBaseが異なっていたらゲージ上書き
        if (saveEBase != ebase)
        {
            //赤ゲージのサイズを緑ゲージと同じにする
            LifeRed.transform.localScale = LifeGreen.transform.localScale;
            //保存している参照元を変更
            saveEBase = ebase;
            //現在のライフを保存
            saveLifeNow = ebase.GetLifeNow();
        }

        //もし赤ゲージが緑ゲージより大きかった場合
        if (LifeRed.transform.localScale.x >= LifeGreen.transform.localScale.x)
        {
            if (ebase.GetLifeNow() <= 0)
            {
                //赤ゲージのサイズを減少
                //体力が０以下の場合は通常速度
                LifeRed.transform.localScale -= new Vector3((float)(saveLifeNow - ebase.GetLifeNow()) / (float)ebase.GetLifeMax() * Time.deltaTime, 0, 0);
            }
            else
            {
                //赤ゲージのサイズを減少
                //ダメージ量が違っていても、赤ゲージの見える時間は等しくなる
                LifeRed.transform.localScale -= new Vector3((float)(saveLifeNow - ebase.GetLifeNow()) / (float)ebase.GetLifeMax() * Time.deltaTime * redGaugeMoveSpeed, 0, 0);
            }
        }
        else
        {
            //赤ゲージと緑ゲージのサイズを等しくする
            LifeRed.transform.localScale = LifeGreen.transform.localScale;
            //現在のライフを保存
            saveLifeNow = ebase.GetLifeNow(); ;
        }

        
    }
}

