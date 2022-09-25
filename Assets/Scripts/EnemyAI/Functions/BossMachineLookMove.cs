using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMachineLookMove : EnemyStateFunction
{
    [Header("���_�̈ړ����x(�⊮�X�s�[�h)")]
    public float step = 1.0f;

    [Header("���_�̍ő�p")]
    public float randomRange_LookMinAngle;
    public float randomRange_LookMaxAngle;
    private Vector3 targetPos;//�^�[�Q�b�g���W�𗐐��Ŏ擾�A�ۑ�����̈�
    public Vector3 GetTargetPos() { return targetPos; }
    private bool angle = true;//True���E�Afalse����(���[���h���W)
    public float GetAnglePos()
    {
        if (angle)
        {
            return -50;
        }
        else
        {
            return 50;
        }
    } 

    [Header("�U���J�n�܂ł̏��v����")]
    public float attackInterval;
    private float nowCount;

    private void Start()
    {
        //�^�񒆂ɑ�����
        Vector3 initPos = new Vector3(0, 0, 10);
        Quaternion rotation = Quaternion.LookRotation(initPos);
        transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, 10000 * Time.deltaTime);
        //�^�[�Q�b�g���W�ݒ�
        TargetPosSetting();
    }


    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //�J�E���g����
        nowCount += tdt;

        // �^�[�Q�b�g�����̃x�N�g�����擾
        Vector3 relativePos = targetPos - this.transform.position;
        // �������A��]���ɕϊ�
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        // ���݂̉�]���ƁA�^�[�Q�b�g�����̉�]����⊮����
        transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, step * tdt);

        //�C���^�[�o�����J�E���g����������U���J�n
        if(attackInterval < nowCount)
        {
           TargetPosSetting();//���̃^�[�Q�b�g���W��ݒ肷��
           return EnemyStateMachine.State.PlayerFind;
        }

        return EnemyStateMachine.State.Now;
    }

    private void TargetPosSetting()
    {
        //�^�[�Q�b�g�ƂȂ���W�������_���Ŏ擾
        float randomPos = Random.Range(
            randomRange_LookMinAngle,
            randomRange_LookMaxAngle
            );

        //���݂̌����ɉ����ċt���̒[���^�[�Q�b�g���W��X���W�����߂�
        float PosX = GetAnglePos();

        //�������ɍ��W�ݒ�
        targetPos = new Vector3(PosX, randomPos, 0);
        
        //���ɎQ�Ƃ���������t�ɂ���
        angle = !angle;
        //�J�E���g���Z�b�g
        nowCount = 0;
    }

}
