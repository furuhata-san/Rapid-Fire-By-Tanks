using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerStandCheck : EnemyStateFunction
{
    [Header("プレイヤーの移動が指定した時間移動していない場合に状態変更")]
    [SerializeField]
    private float playerStandTime;
    private float nowCount;

    [Header("参照するオブジェクト名")]
    [SerializeField]
    private string targetName;
    private GameObject target;
    private Vector3 targetPosBefore;

    [Header("次の状態")]
    [SerializeField]
    private EnemyStateMachine.State nextState;


    // Start is called before the first frame update
    void Start()
    {
        nowCount = 0;
        target = GameObject.Find(targetName);
    }

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //移動していない場合
        if(targetPosBefore == target.transform.position)
        {
            //カウント増加
            nowCount += tdt;

            //時間が経過していたら
            if(nowCount >= playerStandTime)
            {
                //状態変更
                return nextState;
            }
            
        }
        //移動している場合
        else
        {
            //カウントリセット
            nowCount = 0;

            //座標保存
            targetPosBefore = target.transform.position;
        }


        //ここまで来たら現在の状態を返す（一定時間プレイヤーが静止していた場合はここには来ない）
        return EnemyStateMachine.State.Now;
    }
}
