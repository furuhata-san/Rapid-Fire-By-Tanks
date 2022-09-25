using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRigidBodyRandomMove : EnemyStateFunction
{
    [Header("�����̈ړ����x�ݒ�")]
    public float MoveSpeed;

    [Header("�����̉�]���x�Ɖ�]����")]
    public float RotateSpeed;
    public float RotateYTime = 0;
    private float RotateYCnt = 0;//RotateYTime�̓����J�E���g
    private float RotateY = 0;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        RotateYCnt = RotateYTime;
    }

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        InsectRandomMove(tdt);

        return EnemyStateMachine.State.Now;
    }

    private void InsectRandomMove(float tdt)
    {
        //�J�E���g���K��ʂ𒴂��Ă�����
        RotateYCnt += tdt;
        if (RotateYCnt >= RotateYTime)
        {
            //��]�ʂ������_����
            RotateY = Random.Range(-RotateSpeed, RotateSpeed);
            RotateYCnt = 0;
        }

        transform.Translate(0, 0, MoveSpeed * tdt);
        transform.Rotate(0, RotateY * tdt, 0);
    }

}
