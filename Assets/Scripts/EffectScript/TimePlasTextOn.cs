using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlasTextOn : MonoBehaviour
{
    [SerializeField]
    private float addTime;

    void Start()
    {
        GameObject text = GameObject.Find("Canvas").transform.Find("30secondsPlas").gameObject;
        text.SetActive(true);

        TimeAndUIMgr tau = GameObject.Find("GameManagement").GetComponent<TimeAndUIMgr>();
        tau.nowTime += addTime;
    }
}
