using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropBoomAttack : EnemyStateFunction
{
    [Header("¶¬‚·‚é”š’e‚ÌPrefab")]
    public GameObject boomPrefab;

    [Header("”š’e‚ğ¶¬‚·‚éƒCƒ“ƒ^[ƒoƒ‹")]
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
            //”š’e¶¬
            GameObject go = Instantiate(boomPrefab);
            go.transform.position = this.transform.position;

            nowCount -= boomCreateInterval;
        }
        return EnemyStateMachine.State.Now;
    }
}
