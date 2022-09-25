using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanonChanger : MonoBehaviour
{
    [Header("バレットを一つずつ挿入")]
    public GameObject[] Canon = new GameObject[4];

    [Header("武器変更時サウンド")]
    public AudioClip change;
    public AudioClip equal;
    private int nowWeapon = 0;

    public ScoreAndUIMgr sau;

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
    }

    public void OnTriggerEnter(Collider other)
    {
        ItemController Icnt;
        if (Icnt = other.transform.GetComponent<ItemController>())
        {
            //スコアがアタッチされていたらスコアを追加
            if(sau) sau.NowScore += 100;

            if (nowWeapon != Icnt.num)
            {
                Canon_Set(Icnt.num);
                this.GetComponent<AudioSource>().PlayOneShot(change);
                nowWeapon = Icnt.num;
            }
            else
            {
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
