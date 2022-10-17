using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateChangeInterval : EnemyStateFunction
{
    [Header("状態を変更するインターバル")]
    public float changeInterval;
    private float nowCount;

    [Header("インターバル経過後、移行する状態")]
    public EnemyStateMachine.State nextState;
    
    // Start is called before the first frame update
    void Start()
    {
        nowCount = 0;
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        nowCount += Time.deltaTime;

        if(changeInterval <= nowCount)
        {
            nowCount = 0;
            return nextState;
        }

        return EnemyStateMachine.State.Now;
    }
}
