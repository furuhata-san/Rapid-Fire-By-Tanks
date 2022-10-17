using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTank : MonoBehaviour
{
    //���������Ŏg���̂�int  [0->�ҋ@ 1->���j 2->�I��]
    private int flagNum = 0;
    public void ExitSelected() { flagNum = 1; }

    [Header("��Ԃ̃��f���}��")]
    [SerializeField]
    private GameObject tank;

    [Header("�G�t�F�N�g")]
    [SerializeField]
    private GameObject effect;

    // Update is called once per frame
    void Update()
    {
        if (flagNum == 1)
        {
            GameObject go = Instantiate(effect);
            go.transform.position = tank.transform.position;
            tank.SetActive(false);
            flagNum = 2;
        }

    }
}
