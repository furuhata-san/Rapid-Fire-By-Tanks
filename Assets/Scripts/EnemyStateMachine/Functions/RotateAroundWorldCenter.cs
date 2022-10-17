using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundWorldCenter : EnemyStateFunction
{
    [Header("移動（回転）速度")]
    public float addSpeed = 1;
    public float maxSpeed = 5;
    private float nowSpeed;

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //移動速度が最大値ではない場合
        if (nowSpeed < maxSpeed)
        {
            //加速
            nowSpeed += addSpeed * tdt;
        }

        //中心に回転
        transform.RotateAround(Vector3.zero, Vector3.up, nowSpeed * Time.deltaTime);

        return EnemyStateMachine.State.Now;
    }
}
