using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateChangeInterval : EnemyStateFunction
{
    [Header("��Ԃ�ύX����C���^�[�o��")]
    public float changeInterval;
    private float nowCount;

    [Header("�C���^�[�o���o�ߌ�A�ڍs������")]
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
