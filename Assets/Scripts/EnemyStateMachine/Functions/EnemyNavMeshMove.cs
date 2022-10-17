using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshMove : EnemyStateFunction
{
    //�����_���ړ���W������
    [Header("�����_���ړ��̋���")]
    public float wanderRange;
    private NavMeshAgent navMeshAgent;
    private NavMeshHit navMeshHit;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //�����_���ړ�
        RandomMove();

        return EnemyStateMachine.State.Now;
    }

    public void RandomMove()//�����_���ړ�
    {
        //�i�r���b�V���Ń����_���ړ�
        if (navMeshAgent == null) return;

        //�ڕW�n�_�ɓ��B�����ꍇ�́A�ڕW�n�_�̕ύX���s��
        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath ||
                    navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    SetDestination();//�ڕW�n�_�ύX
                    return;
                }
            }
        }
        return;
    }

    private void SetDestination()//�ڕW�n�_��Bake����Ă���n�_���烉���_���őI��
    {
        Vector3 randomPos = new Vector3(Random.Range(-wanderRange, wanderRange), 0, Random.Range(-wanderRange, wanderRange));
        NavMesh.SamplePosition(randomPos, out navMeshHit, 5, 1);
        navMeshAgent.destination = navMeshHit.position;
    }
}
