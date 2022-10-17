using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerStandCheck : EnemyStateFunction
{
    [Header("�v���C���[�̈ړ����w�肵�����Ԉړ����Ă��Ȃ��ꍇ�ɏ�ԕύX")]
    [SerializeField]
    private float playerStandTime;
    private float nowCount;

    [Header("�Q�Ƃ���I�u�W�F�N�g��")]
    [SerializeField]
    private string targetName;
    private GameObject target;
    private Vector3 targetPosBefore;

    [Header("���̏��")]
    [SerializeField]
    private EnemyStateMachine.State nextState;


    // Start is called before the first frame update
    void Start()
    {
        nowCount = 0;
        target = GameObject.Find(targetName);
    }

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //�ړ����Ă��Ȃ��ꍇ
        if(targetPosBefore == target.transform.position)
        {
            //�J�E���g����
            nowCount += tdt;

            //���Ԃ��o�߂��Ă�����
            if(nowCount >= playerStandTime)
            {
                //��ԕύX
                return nextState;
            }
            
        }
        //�ړ����Ă���ꍇ
        else
        {
            //�J�E���g���Z�b�g
            nowCount = 0;

            //���W�ۑ�
            targetPosBefore = target.transform.position;
        }


        //�����܂ŗ����猻�݂̏�Ԃ�Ԃ��i��莞�ԃv���C���[���Î~���Ă����ꍇ�͂����ɂ͗��Ȃ��j
        return EnemyStateMachine.State.Now;
    }
}
