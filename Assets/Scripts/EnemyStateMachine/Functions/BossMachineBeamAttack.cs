using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMachineBeamAttack : EnemyStateFunction
{

    [Header("�uBossMachineLookMove�v�ƘA�g������i���������킹�邽�߁j")]
    public BossMachineLookMove bmlmScript;

    [Header("��]���x�i�r�[���ガ�������x�j")]
    [SerializeField]
    private float rotateSpeed;

    [Header("�Ǝ˕b��")]
    [SerializeField]
    private float beamShotTime;
    private float nowCount;

    // Start is called before the first frame update
    void Start()
    {
        nowCount = 0;
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        nowCount += tdt;

        //�^�[�Q�b�g���W���l��
        float targetPosX = -bmlmScript.GetAnglePos();

        float speed = 0;
        if(targetPosX < 0)
        {
            speed = -rotateSpeed;
        }
        else
        {
            speed = rotateSpeed;
        }

        transform.Rotate(Vector3.up, speed * tdt);

        //�C���^�[�o�����J�E���g����������U���I��
        if (beamShotTime < nowCount)
        {
            nowCount = 0;
            return EnemyStateMachine.State.Vigilance;
        }

        return EnemyStateMachine.State.Now;
    }
}
