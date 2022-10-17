using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodeSoon : EnemyStateFunction
{
    [Header("死亡時のエフェクトの設定")]
    public GameObject DestroyEffect;
    public Vector3 DieEffectScale;

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //即時爆破
        //爆発エフェクトを生成
        GameObject go = Instantiate(DestroyEffect) as GameObject;
        go.transform.position = this.transform.position;//位置を敵の位置へ移動
        go.GetComponent<EffectController>().Scale = DieEffectScale;//大きさ変更

        //破壊
        Destroy(gameObject);//仮処理

        return EnemyStateMachine.State.Now;
    }
}

