using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMachineBeamAttack : EnemyStateFunction
{

    [Header("「BossMachineLookMove」と連携させる（向きを合わせるため）")]
    public BossMachineLookMove bmlmScript;

    [Header("回転速度（ビーム薙ぎ払い速度）")]
    [SerializeField]
    private float rotateSpeed;

    [Header("照射秒数")]
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

        //ターゲット座標を獲得
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

        //インターバルをカウントが超えたら攻撃終了
        if (beamShotTime < nowCount)
        {
            nowCount = 0;
            return EnemyStateMachine.State.Vigilance;
        }

        return EnemyStateMachine.State.Now;
    }
}
