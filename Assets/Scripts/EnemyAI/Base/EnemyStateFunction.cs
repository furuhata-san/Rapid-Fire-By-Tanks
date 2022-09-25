using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateFunction : MonoBehaviour
{
    /*
        Vigilance,  //警戒モード
        PlayerFind, //発見・攻撃モード
        EnemyDie, //削除モード
    */

    public virtual EnemyStateMachine.State EnemyMove(float tdt)
    {
        //オーバーライド用
        return EnemyStateMachine.State.Non;
    }
}
