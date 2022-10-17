using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightOf : EnemyStateFunction
{
    [Header("プレイヤーの距離が指定距離より離れたら状態変化")]
    [SerializeField]
    private float distance;

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
        target = GameObject.Find(targetName);
    }

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //自身から見た距離の計算
        Vector3 dir = transform.position - target.transform.position;
        
        //距離が離れていたら状態変更
        if(dir.magnitude >= distance)
        {
            return nextState;
        }
        return EnemyStateMachine.State.Now;
    }
}
