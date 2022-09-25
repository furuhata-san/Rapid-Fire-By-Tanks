using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshMove : EnemyStateFunction
{
    //ランダム移動を標準装備
    [Header("ランダム移動の距離")]
    public float wanderRange;
    private NavMeshAgent navMeshAgent;
    private NavMeshHit navMeshHit;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //ランダム移動
        RandomMove();

        return EnemyStateMachine.State.Now;
    }

    public void RandomMove()//ランダム移動
    {
        //ナビメッシュでランダム移動
        if (navMeshAgent == null) return;

        //目標地点に到達した場合は、目標地点の変更を行う
        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath ||
                    navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    SetDestination();//目標地点変更
                    return;
                }
            }
        }
        return;
    }

    private void SetDestination()//目標地点をBakeされている地点からランダムで選ぶ
    {
        Vector3 randomPos = new Vector3(Random.Range(-wanderRange, wanderRange), 0, Random.Range(-wanderRange, wanderRange));
        NavMesh.SamplePosition(randomPos, out navMeshHit, 5, 1);
        navMeshAgent.destination = navMeshHit.position;
    }
}
