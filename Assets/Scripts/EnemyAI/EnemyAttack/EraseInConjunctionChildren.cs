using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseInConjunctionChildren : MonoBehaviour
{
    [Header("���̃X�N���v�g�͐e�I�u�W�F�N�g�ɃA�^�b�`����\n�q�I�u�W�F�N�g�i�A�������ď��������I�u�W�F�N�g�j��}��")]
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
