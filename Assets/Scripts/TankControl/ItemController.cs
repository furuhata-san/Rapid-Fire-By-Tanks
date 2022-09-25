using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject[] Item = new GameObject[4];
    public int num;

    private float destroyCnt = 0;
    public float DestroyMax = 0;
    // Start is called before the first frame update
    void Start()
    {
        num = Random.Range(0, Item.Length);
        Item[num].SetActive(true);

        destroyCnt = 0;
    }

    private void Update()
    {
        destroyCnt += Time.deltaTime;     
    }

    //カメラに写っていないかつ、アイテムの生存時間切れ
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
