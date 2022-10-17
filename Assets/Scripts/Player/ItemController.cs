using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [Header("�����������A�C�e�����f����}��")]
    [SerializeField]
    private GameObject[] Item = new GameObject[4];
    private int item_number;
    public int GetItemNumber() { return item_number; }
  
    [Header("�A�C�e���̐������ԁi���Ԍo�ߌ�A�J�����O�ɂȂ�ƃA�C�e���폜�j")]
    [SerializeField]
    private float DestroyMax = 0;
    private float destroyCnt = 0;


    // Start is called before the first frame update
    void Start()
    {
        item_number = Random.Range(0, Item.Length);
        Item[item_number].SetActive(true);

        destroyCnt = 0;
    }

    private void Update()
    {
        destroyCnt += Time.deltaTime;     
    }

    //�J�����Ɏʂ��Ă��Ȃ����A�A�C�e���̐������Ԑ؂�ŃA�C�e���폜
    private void OnBecameInvisible()
    {
        if (destroyCnt >= DestroyMax)
        {
            //�j��
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
