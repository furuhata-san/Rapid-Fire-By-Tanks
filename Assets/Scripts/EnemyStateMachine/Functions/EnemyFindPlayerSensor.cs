using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFindPlayerSensor : EnemyStateFunction
{
    EnemyStateMachine.State findState;//常にこの値をステートマシンに返す戻り値とする
    [Header("感知したいオブジェクトのタグ名")]
    public string tagName;

    private void Start()
    {
        //初期化（発見していない状態）
        findState = EnemyStateMachine.State.Now;
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //OnTriggerStayで処理を行う
        return findState;
    }

    private void OnTriggerStay(Collider other)
    {
        //発見したいタグと一致した場合は
        if(other.transform.tag == tagName)
        {
            //プレイヤ発見状態へ移行
            findState = EnemyStateMachine.State.PlayerFind;
        }
    }
}
