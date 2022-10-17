using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipDamageAreaActivate : EnemyStateFunction
{
    [Header("疑似的にスリップダメージにしたい場合、コライダー（当たり判定）を参照する")]
    public GameObject hitArea;
    [SerializeField]
    private bool startSetActive = true;

    [Header("有効化（無効化）状態に切り替える時間")]
    public float intervalGoToFalse;
    public float intervalGoToTrue;
    private float nowCount;

    // Start is called before the first frame update
    void Start()
    {
        hitArea.SetActive(startSetActive);
    }

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        nowCount += Time.deltaTime;

        float intervalCopy = 0;
        if (hitArea.activeInHierarchy)//コライダー有効時
        {
            intervalCopy = intervalGoToFalse;
        }
        else//コライダー無効時
        {
            intervalCopy = intervalGoToTrue;
        }

        if (nowCount >= intervalCopy)
        {
            //フラグ反転
            hitArea.SetActive(!hitArea.activeInHierarchy);
            nowCount = 0;
        }

        return EnemyStateMachine.State.Now;
    }
}
