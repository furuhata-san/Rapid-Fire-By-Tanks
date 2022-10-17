using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAndUIMgr : MonoBehaviour
{
    [Header("タイマーのイメージとテキスト")]
    public Image timer;
    public Text text;
    [Header("残り30秒時に表示するテキスト")]
    public GameObject thirtySec;
    private bool thirtySecFlag = false;
    [Header("制限時間")]
    [SerializeField]
    private float TimeLimit = 10.0f;
    public float nowTime;
    public GameObject finishText;
    [Header("オーディオソースの挿入")]
    public AudioSource gameBGM;
    [Range(0.0f,3.0f)]
    public float fastPitch = 1.2f;
    [Range(0.0f, 3.0f)]
    public float slowPitch = 1.0f;
    [Header("シーン移行のオブジェクト")]
    public SceneAndFadeOutMgr sceneMgr;
    public AudioClip gong;
    private bool gongFlag = true;
    [Header("時間切れの際、無効化するオブジェクト")]
    public GameObject TankCanon;
    // Start is called before the first frame update
    void Start()
    {
        nowTime = TimeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        //ゲージ変動
        timer.fillAmount = (nowTime / TimeLimit);

        //テキスト変更
        nowTime -= Time.deltaTime;
        if (nowTime <= 0)
        {
            nowTime = 0;  //時間が負の値の場合０に上書き
            if (gongFlag)
            {
                //キャノン無効化
                TankCanon.SetActive(false);
                //フィニッシュテキスト有効化
                finishText.SetActive(true);
                gameBGM.Stop();
                this.GetComponent<AudioSource>().PlayOneShot(gong);
                sceneMgr.Go_Result();
                gongFlag = false;
            }
        }

        //残り30秒テキスト
        if (thirtySecFlag)
        {
            if (nowTime <= 30.0f)//三十秒以下
            {
                thirtySec.SetActive(true);
                gameBGM.pitch = fastPitch;
                thirtySecFlag = false;
            }
        }
        else if(nowTime > 30.0f)//三十秒以上なら再度有効化
        {
            gameBGM.pitch = slowPitch;
            thirtySecFlag = true;
        }

        //デバッグ用コード
        if (Input.GetKey(KeyCode.F5))
        {
            nowTime += Time.deltaTime * 50;
        }
        else if (Input.GetKey(KeyCode.F6))
        {
            nowTime -= Time.deltaTime * 50;
        }

        //制限時間より大きい場合
        if(nowTime > TimeLimit)
        {
            //最大値以上にならないよう補正
            nowTime = TimeLimit;
        }

        text.text = "" + (int)nowTime; //時間が10超過の場合に表示
    }
}
