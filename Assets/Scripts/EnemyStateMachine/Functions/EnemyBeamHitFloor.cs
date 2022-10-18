using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeamHitFloor : EnemyStateFunction
{
    [Header("生成するエフェクトと生成間隔")]
    [SerializeField]
    private GameObject effect;
    [SerializeField]
    private float craeteInterval;
    private float nowCreateCount;

    // Start is called before the first frame update
    void Start()
    {
        nowCreateCount = 0;
    }

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //カウント増加
        nowCreateCount += tdt;
        return EnemyStateMachine.State.Now;
    }

    private void OnTriggerStay(Collider other)
    {
        //エフェクト生成周期を超えたら
        if (nowCreateCount >= craeteInterval)
        {
            //Rayを発射し、着弾地点にエフェクトを表示
            Ray machineBeam = new Ray(this.transform.position, this.transform.up);
            RaycastHit beamHit;
            if(Physics.Raycast(machineBeam, out beamHit))
            {
                if (beamHit.transform.name == "Plane")
                {
                    // RayがColliderと衝突した地点の座標を取得
                    Vector3 targetPos = beamHit.point;

                    //エフェクト生成
                    GameObject go = Instantiate(effect);
                    effect.transform.position = targetPos;
                }
            }

            //カウント減少
            nowCreateCount -= craeteInterval;
        }
    }
}