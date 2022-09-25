using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcellentTextOn : MonoBehaviour
{

    void Start()
    {
        GameObject text = GameObject.Find("Canvas").transform.Find("Excellent").gameObject;
        text.SetActive(true);
    }
}
