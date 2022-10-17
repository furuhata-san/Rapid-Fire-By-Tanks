using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanonChanger : MonoBehaviour
{
    [Header("バレットを一つずつ挿入")]
    [SerializeField]
    private GameObject[] Canon = new GameObject[4];

    [Header("武器変更時サウンド")]
    [SerializeField]
    private AudioClip change;
    [SerializeField]
    private AudioClip equal;
    private int nowWeapon = 0;

    [Header("変更が発生した際にエフェクト発生")]
    [SerializeField]
    private ParticleSystem effect;

    [Header("スコアマネージャーを参照")]
    [SerializeField]
    private ScoreAndUIMgr sau;

    // Start is called before the first frame update
    void Start()
    {
        //初期化及び通常バレットの有効化
        Canon_Alloff();
        Canon[0].SetActive(true);
        nowWeapon = 0;
    }

    public void Canon_Alloff()
    {
        for(int i = 0; i < Canon.Length; ++i)
        {
            Canon[i].SetActive(false);
        }
    }

    public void Canon_Set(int nomber)
    {
        Canon_Alloff();
        Canon[nomber].SetActive(true);
        nowWeapon = nomber;
    }

    public void OnTriggerEnter(Collider other)
    {
        ItemController Icnt;
        if (Icnt = other.transform.GetComponent<ItemController>())
        {
            //スコアがアタッチされていたらスコアを追加
            if(sau) sau.NowScore += 100;

            //違う武器だった場合
            if (nowWeapon != Icnt.GetItemNumber())
            {
                //砲台変更
                Canon_Set(Icnt.GetItemNumber());
                //効果音を鳴らす
                this.GetComponent<AudioSource>().PlayOneShot(change);
                //エフェクト再生
                effect.Play();
                
            }
            //同じ武器だった場合
            else
            {
                //効果音のみ
                this.GetComponent<AudioSource>().PlayOneShot(equal);
            }
        }
        //チュートリアル用
        else if (other.transform.GetComponent<ItemTutorial>())
        {
            Canon_Set(other.transform.GetComponent<ItemTutorial>().num);
            this.GetComponent<AudioSource>().PlayOneShot(change);
            nowWeapon = other.transform.GetComponent<ItemTutorial>().num;
        }
    }
}
