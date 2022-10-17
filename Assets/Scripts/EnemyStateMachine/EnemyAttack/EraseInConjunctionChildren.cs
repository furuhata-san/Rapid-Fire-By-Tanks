using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseInConjunctionChildren : MonoBehaviour
{
    [Header("このスクリプトは親オブジェクトにアタッチする\n子オブジェクト（連動させて消したいオブジェクト）を挿入")]
    public GameObject childObject;

    // Update is called once per frame
    void Update()
    {
        if (!childObject)
        {
            Destroy(gameObject);
        }
    }
}
