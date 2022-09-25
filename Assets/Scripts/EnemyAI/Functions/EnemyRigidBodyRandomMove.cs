using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRigidBodyRandomMove : EnemyStateFunction
{
    [Header("昆虫の移動速度設定")]
    public float MoveSpeed;

    [Header("昆虫の回転速度と回転時間")]
    public float RotateSpeed;
    public float RotateYTime = 0;
    private float RotateYCnt = 0;//RotateYTimeの内部カウント
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
        //カウントが規定量を超えていたら
        RotateYCnt += tdt;
        if (RotateYCnt >= RotateYTime)
        {
            //回転量をランダムに
            RotateY = Random.Range(-RotateSpeed, RotateSpeed);
            RotateYCnt = 0;
        }

        transform.Translate(0, 0, MoveSpeed * tdt);
        transform.Rotate(0, RotateY * tdt, 0);
    }

}
