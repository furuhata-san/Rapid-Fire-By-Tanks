using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationSpeedChanger : EnemyStateFunction
{
    [Header("�i�r���b�V���̈ړ����x�ɉ����ăA�j���[�V�����̍Đ����x��ύX")]
    [SerializeField]
    private Animator[] animator = new Animator[1];
    [Header("�A�j���[�V�������x�ύX����")]
    [SerializeField]
    private float animSpeedVal;
    [Header("�i�r���b�V���̑��x�ɂ���ĕύX���s��")]
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //���݂̈ړ����x�̃x�N�g��
        Vector3 nowSpeed = navMeshAgent.velocity;
        float nowMoveSpeed = nowSpeed.magnitude;

        for (int i = 0; i < animator.Length; ++i)
        {
            animator[i].speed = nowMoveSpeed * animSpeedVal;
        }

        //�ύX�͂��Ȃ�
        return EnemyStateMachine.State.Now;
    }
}
