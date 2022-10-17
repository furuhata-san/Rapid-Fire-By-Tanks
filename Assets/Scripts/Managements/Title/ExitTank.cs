using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTank : MonoBehaviour
{
    //ここだけで使うのでint  [0->待機 1->爆破 2->終了]
    private int flagNum = 0;
    public void ExitSelected() { flagNum = 1; }

    [Header("戦車のモデル挿入")]
    [SerializeField]
    private GameObject tank;

    [Header("エフェクト")]
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
