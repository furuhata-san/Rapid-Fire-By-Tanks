using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyKnockdown : EnemyStateFunction
{
    [Header("倒れる速度")]
    public float rotateSpeed;
    public Vector3 dieRotatePow;

    [Header("倒れはじめてから、爆破するまでの時間")]
    public float destroyTime;
    private float destroyTimer;    

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
        EnemyDieRotate(tdt);

        return EnemyStateMachine.State.Now;
    }

    public void EnemyDieRotate(float tdt)
    {
        //カウントを増やす
        destroyTimer += tdt;

        //ナビメッシュエージェント無効化
        NavMeshAgentDelete();

        //回転させる
        float rot = ((rotateSpeed) * tdt) / destroyTime;
        Vector3 rotSet = new Vector3(rot * dieRotatePow.x, rot * dieRotatePow.y, rot * dieRotatePow.z);
        transform.Rotate(rotSet);

        if (destroyTimer >= destroyTime) //指定秒数経過後
        {
            //爆発エフェクトを生成
            GameObject go = Instantiate(destroyEffect) as GameObject;
            go.transform.position = this.transform.position;//位置を敵の位置へ移動
            go.GetComponent<EffectController>().Scale = effectScale;//大きさ変更

            //無効化もしくは破壊
            //state = State.Non;
            Destroy(gameObject);//仮処理
        }
    }

    public void NavMeshAgentDelete()//ナビメッシュコンポーネント削除
    {
        if (NMA != null)
        {
            Destroy(NMA);
        }
    }
}
