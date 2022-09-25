using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundWorldCenter : EnemyStateFunction
{
    [Header("�ړ��i��]�j���x")]
    public float addSpeed = 1;
    public float maxSpeed = 5;
    private float nowSpeed;

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //�ړ����x���ő�l�ł͂Ȃ��ꍇ
        if (nowSpeed < maxSpeed)
        {
            //����
            nowSpeed += addSpeed * tdt;
        }

        //���S�ɉ�]
        transform.RotateAround(Vector3.zero, Vector3.up, nowSpeed * Time.deltaTime);

        return EnemyStateMachine.State.Now;
    }
}
