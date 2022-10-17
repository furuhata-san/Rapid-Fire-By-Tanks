using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock360AndPlayerFind : EnemyStateFunction
{
    [Header("��]���x")]
    public float rotateMaxSpeed;
    public Vector2 rotateChengeIntervalRange;
    private float rotateNowSpeed;
    private float rotateNowInterval;

    [Header("�v���C���[�̒T�m�͈�")]
    public float playerDistance;
    private Transform target;

    void Start()
    {
        //�v���C���[���������A�^�[�Q�b�g�Ƃ���
        target = GameObject.Find("PlayerTank").transform;
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        rotateNowInterval -= Time.deltaTime;
        if (rotateNowInterval <= 0)
        {
            rotateNowSpeed = Random.Range(-rotateMaxSpeed, rotateMaxSpeed);
            rotateNowInterval = Random.Range(rotateChengeIntervalRange.x, rotateChengeIntervalRange.y);
        }
        float step = rotateNowSpeed * tdt;
        transform.Rotate(Vector3.up, step);

        //�^�[�Q�b�g�Ƃ̋�������苗���ȓ��������ꍇ�A������Ԃֈڍs���鏈��
        {
            //X�EZ������Ƀv���C���Ƃ̋����𑪂�A
            //�w��̋����܂Őڋ߂�����A�v���C��������Ԃ֕ύX
            Vector2 targetVec2 = new Vector2(target.transform.position.x, target.transform.position.z);
            Vector2 myVec2 = new Vector2(this.transform.position.x, this.transform.position.z);

            //���g�ƃ^�[�Q�b�g�Ƃ̋��������߂�
            Vector2 distance = myVec2 - targetVec2;
            float magnitude = distance.magnitude;

            //�������T�m�͈͂̋����������Ȃ�
            if (magnitude <= playerDistance)
            {
                //�v���C������
                return EnemyStateMachine.State.PlayerFind;
            }
            //���݂̏�Ԃ��ێ�
            return EnemyStateMachine.State.Now;
        }
    }
}
