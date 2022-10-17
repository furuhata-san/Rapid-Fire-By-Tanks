using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFallDie : EnemyStateFunction
{
    [Header("落下速度")]
    public float fallSpeed;

    [Header("落下開始してから、爆破するまでの時間")]
    public float destroyTime;
    private float destroyTimer;

    [Header("死亡時回転速度と速度倍率")]
    public float dieRotateSpeed;
    public Vector3 dieRotatePow;

    [Header("死亡時エフェクト")]
    public GameObject destroyEffect;
    public Vector3 effectScale;
    private NavMeshAgent NMA;

    private void Start()
    {
        destroyTimer = 0;
        NMA = GetComponent<NavMeshAgent>();
    }


    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //落下して移動（NavMesh）
        EnemyDieFallAndRotateY(tdt);

        return EnemyStateMachine.State.Now;
    }


    public void EnemyDieFallAndRotateY(float tdt)
    {

        //カウントを増やす
        destroyTimer += tdt;

        //ナビメッシュエージェント無効化
        NavMeshAgentOff();

        //回転させる
        float rot = ((dieRotateSpeed) * tdt) / destroyTime;
        Vector3 rotSet = new Vector3(rot * dieRotatePow.x, rot * dieRotatePow.y, rot * dieRotatePow.z);
        transform.Rotate(rotSet);

        //下へ移動
        float Pos = fallSpeed * tdt;
        NMA.baseOffset -= Pos;


        if (destroyTimer >= destroyTime) //指定秒数経過後
        {
            //爆発エフェクトを生成
            GameObject go = Instantiate(destroyEffect) as GameObject;
            go.transform.position = this.transform.position;//位置を敵の位置へ移動
            go.GetComponent<EffectController>().Scale = effectScale;//大きさ変更

            //破壊
            Destroy(gameObject);
        }
    }

    public void NavMeshAgentOff()//ナビメッシュ無効化
    {
        //移動と回転を停止[

        NMA.speed = 0;
        NMA.angularSpeed = 0;
    }
}
