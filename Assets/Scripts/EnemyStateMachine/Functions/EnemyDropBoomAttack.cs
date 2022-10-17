using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropBoomAttack : EnemyStateFunction
{
    [Header("�������锚�e��Prefab")]
    public GameObject boomPrefab;

    [Header("���e�𐶐�����C���^�[�o��")]
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
            //���e����
            GameObject go = Instantiate(boomPrefab);
            go.transform.position = this.transform.position;

            nowCount -= boomCreateInterval;
        }
        return EnemyStateMachine.State.Now;
    }
}
