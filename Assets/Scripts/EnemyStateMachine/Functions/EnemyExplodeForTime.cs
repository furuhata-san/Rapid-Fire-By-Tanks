using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodeForTime : EnemyStateFunction
{
    [Header("死亡してから削除までの時間")]
    public float destroyTime;//死亡時間
    private float destroyCount;//死亡時内部カウント

    [Header("死亡時エフェクト")]
    public GameObject DestroyEffect;
    public Vector3 DieEffectScale;

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //カウントを増やす
        destroyCount += tdt;

        //当たり判定をなくす
        Rigidbody rb;
        if (rb = GetComponent<Rigidbody>())
        {
            rb.isKinematic = true;
        }

        if (destroyCount >= destroyTime) //指定秒数経過後
        {
            //爆発エフェクトを生成
            GameObject go = Instantiate(DestroyEffect) as GameObject;
            go.transform.position = this.transform.position;//位置を敵の位置へ移動
            go.GetComponent<EffectController>().Scale = DieEffectScale;//大きさ変更

            //破壊
            Destroy(gameObject);
        }

        return EnemyStateMachine.State.Now;
    }
}
