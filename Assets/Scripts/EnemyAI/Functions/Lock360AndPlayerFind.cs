using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock360AndPlayerFind : EnemyStateFunction
{
    [Header("回転速度")]
    public float rotateMaxSpeed;
    public Vector2 rotateChengeIntervalRange;
    private float rotateNowSpeed;
    private float rotateNowInterval;

    [Header("プレイヤーの探知範囲")]
    public float playerDistance;
    private Transform target;

    void Start()
    {
        //プレイヤーを検索し、ターゲットとする
        target = GameObject.Find("PlayerTank").transform;
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        rotateNowInterval -= Time.deltaTime;
        if (rotateNowInterval <= 0)
        {
            rotateNowSpeed = Random.Range(-rotateMaxSpeed, rotateMaxSpeed);
            rotateNowInterval = Random.Range(rotateChengeIntervalRange.x, rotateChengeIntervalRange.y);
        }
        float step = rotateNowSpeed * tdt;
        transform.Rotate(Vector3.up, step);

        //ターゲットとの距離が一定距離以内だった場合、発見状態へ移行する処理
        {
            //X・Z軸を基準にプレイヤとの距離を測り、
            //指定の距離まで接近したら、プレイヤ発見状態へ変更
            Vector2 targetVec2 = new Vector2(target.transform.position.x, target.transform.position.z);
            Vector2 myVec2 = new Vector2(this.transform.position.x, this.transform.position.z);

            //自身とターゲットとの距離を求める
            Vector2 distance = myVec2 - targetVec2;
            float magnitude = distance.magnitude;

            //距離が探知範囲の距離より内側なら
            if (magnitude <= playerDistance)
            {
                //プレイヤ発見
                return EnemyStateMachine.State.PlayerFind;
            }
            //現在の状態を維持
            return EnemyStateMachine.State.Now;
        }
    }
}
