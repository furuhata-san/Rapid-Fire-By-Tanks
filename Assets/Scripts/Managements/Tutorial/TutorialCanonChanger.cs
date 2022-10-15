using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanonChanger : MonoBehaviour
{
    [Header("�o���b�g������}��")]
    public GameObject[] Canon = new GameObject[4];

    [Header("����ύX���T�E���h")]
    public AudioClip clip;
    private int nowWeapon = 0;

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
        for (int i = 0; i < Canon.Length; ++i)
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
        ItemTutorial Icnt;
        if (Icnt = other.transform.GetComponent<ItemTutorial>())
        {
            if (nowWeapon != Icnt.num)
            {
                Canon_Set(Icnt.num);
                this.GetComponent<AudioSource>().PlayOneShot(clip);
                nowWeapon = Icnt.num;
            }
        }
    }
}
