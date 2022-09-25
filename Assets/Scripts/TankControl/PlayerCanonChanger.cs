using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanonChanger : MonoBehaviour
{
    [Header("�o���b�g������}��")]
    public GameObject[] Canon = new GameObject[4];

    [Header("����ύX���T�E���h")]
    public AudioClip change;
    public AudioClip equal;
    private int nowWeapon = 0;

    public ScoreAndUIMgr sau;

    // Start is called before the first frame update
    void Start()
    {
        //�������y�ђʏ�o���b�g�̗L����
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
            //�X�R�A���A�^�b�`����Ă�����X�R�A��ǉ�
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
        //�`���[�g���A���p
        else if (other.transform.GetComponent<ItemTutorial>())
        {
            Canon_Set(other.transform.GetComponent<ItemTutorial>().num);
            this.GetComponent<AudioSource>().PlayOneShot(change);
            nowWeapon = other.transform.GetComponent<ItemTutorial>().num;
        }
    }
}
