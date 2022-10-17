using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [Header("生成したいアイテムモデルを挿入")]
    [SerializeField]
    private GameObject[] Item = new GameObject[4];
    private int item_number;
    public int GetItemNumber() { return item_number; }
  
    [Header("アイテムの生存時間（時間経過後、カメラ外になるとアイテム削除）")]
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

    //カメラに写っていないかつ、アイテムの生存時間切れでアイテム削除
    private void OnBecameInvisible()
    {
        if (destroyCnt >= DestroyMax)
        {
            //破壊
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
