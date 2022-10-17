using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanonChanger : MonoBehaviour
{
    [Header("�o���b�g������}��")]
    [SerializeField]
    private GameObject[] Canon = new GameObject[4];

    [Header("����ύX���T�E���h")]
    [SerializeField]
    private AudioClip change;
    [SerializeField]
    private AudioClip equal;
    private int nowWeapon = 0;

    [Header("�ύX�����������ۂɃG�t�F�N�g����")]
    [SerializeField]
    private ParticleSystem effect;

    [Header("�X�R�A�}�l�[�W���[���Q��")]
    [SerializeField]
    private ScoreAndUIMgr sau;

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
        nowWeapon = nomber;
    }

    public void OnTriggerEnter(Collider other)
    {
        ItemController Icnt;
        if (Icnt = other.transform.GetComponent<ItemController>())
        {
            //�X�R�A���A�^�b�`����Ă�����X�R�A��ǉ�
            if(sau) sau.NowScore += 100;

            //�Ⴄ���킾�����ꍇ
            if (nowWeapon != Icnt.GetItemNumber())
            {
                //�C��ύX
                Canon_Set(Icnt.GetItemNumber());
                //���ʉ���炷
                this.GetComponent<AudioSource>().PlayOneShot(change);
                //�G�t�F�N�g�Đ�
                effect.Play();
                
            }
            //�������킾�����ꍇ
            else
            {
                //���ʉ��̂�
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
