using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFindPlayerSensor : EnemyStateFunction
{
    EnemyStateMachine.State findState;//��ɂ��̒l���X�e�[�g�}�V���ɕԂ��߂�l�Ƃ���
    [Header("���m�������I�u�W�F�N�g�̃^�O��")]
    public string tagName;

    private void Start()
    {
        //�������i�������Ă��Ȃ���ԁj
        findState = EnemyStateMachine.State.Now;
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //OnTriggerStay�ŏ������s��
        return findState;
    }

    private void OnTriggerStay(Collider other)
    {
        //�����������^�O�ƈ�v�����ꍇ��
        if(other.transform.tag == tagName)
        {
            //�v���C��������Ԃֈڍs
            findState = EnemyStateMachine.State.PlayerFind;
        }
    }
}
