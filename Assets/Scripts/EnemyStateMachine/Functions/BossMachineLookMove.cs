using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMachineLookMove : EnemyStateFunction
{
    [Header("視点の移動速度(補完スピード)")]
    public float step = 1.0f;

    [Header("視点の最大角")]
    public float randomRange_LookMinAngle;
    public float randomRange_LookMaxAngle;
    private Vector3 targetPos;//ターゲット座標を乱数で取得、保存する領域
    public Vector3 GetTargetPos() { return targetPos; }
    private bool angle = true;//Trueが右、falseが左(ワールド座標)
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

    [Header("攻撃開始までの所要時間")]
    public float attackInterval;
    private float nowCount;

    private void Start()
    {
        //真ん中に即向く
        Vector3 initPos = new Vector3(0, 0, 10);
        Quaternion rotation = Quaternion.LookRotation(initPos);
        transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, 10000 * Time.deltaTime);
        //ターゲット座標設定
        TargetPosSetting();
    }


    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //カウント増加
        nowCount += tdt;

        // ターゲット方向のベクトルを取得
        Vector3 relativePos = targetPos - this.transform.position;
        // 方向を、回転情報に変換
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        // 現在の回転情報と、ターゲット方向の回転情報を補完する
        transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, step * tdt);

        //インターバルをカウントが超えたら攻撃開始
        if(attackInterval < nowCount)
        {
           TargetPosSetting();//次のターゲット座標を設定する
           return EnemyStateMachine.State.PlayerFind;
        }

        return EnemyStateMachine.State.Now;
    }

    private void TargetPosSetting()
    {
        //ターゲットとなる座標をランダムで取得
        float randomPos = Random.Range(
            randomRange_LookMinAngle,
            randomRange_LookMaxAngle
            );

        //現在の向きに応じて逆側の端をターゲット座標のX座標を決める
        float PosX = GetAnglePos();

        //情報を元に座標設定
        targetPos = new Vector3(PosX, randomPos, 0);
        
        //次に参照する向きを逆にする
        angle = !angle;
        //カウントリセット
        nowCount = 0;
    }

}
