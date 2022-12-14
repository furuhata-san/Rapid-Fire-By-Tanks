using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropBoomAttack : EnemyStateFunction
{
    [Header("生成する爆弾のPrefab")]
    public GameObject boomPrefab;

    [Header("爆弾を生成するインターバル")]
    public float boomCreateInterval;
    public float nowCountInit;
    private float nowCount;

    // Start is called before the first frame update
    void Start()
    {
        nowCount = nowCountInit;
    }

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        nowCount += Time.deltaTime;
        if(boomCreateInterval <= nowCount)
        {
            //爆弾生成
            GameObject go = Instantiate(boomPrefab);
            go.transform.position = this.transform.position;

            nowCount -= boomCreateInterval;
        }
        return EnemyStateMachine.State.Now;
    }
}
