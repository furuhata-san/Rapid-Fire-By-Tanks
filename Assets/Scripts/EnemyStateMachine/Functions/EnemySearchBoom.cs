using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySearchBoom : EnemyStateFunction
{
    private GameObject player;//プレイヤーに向かって進む
    private NavMeshAgent navMeshAgent;//ナビメッシュ
    private NavMeshHit navMeshHit;
    [Header("プレイヤ発見時、移動速度を上書きする")]
    public float speedUp;
    [Header("プレイヤ発見時、アニメーションの速度更新")]
    public Animator bootingAnimator;
    public float animPlaySpeed;

    [Header("プレイヤーが指定した距離まで接近した場合、爆発")]
    public float boomDistance;
    public GameObject boomObject;
    public Vector3 boomScale;
    private bool boomStart;

    [Header("指定したカウントを超えたら爆発する")]
    public float boomTime;
    private float nowCount;

    [Header("爆発開始時のサウンド（導火線など）")]
    public AudioSource fuseAudioSource;

    private void Start()
    {
        player = GameObject.Find("PlayerTank");
        navMeshAgent = GetComponent<NavMeshAgent>();
        nowCount = 0;
        boomStart = false;
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //上書き
        navMeshAgent.speed = speedUp;
        bootingAnimator.speed = animPlaySpeed;

        SearchPlayer();
        Boom(tdt);

        //ずっと変更しない
        return EnemyStateMachine.State.Now;
    }

    public void Boom(float tdt)//ランダム移動
    {
        //ナビメッシュがない場合は処理を行わない
        //if (navMeshAgent == null) return;（ナビメッシュがないとそもそも動かないため、エラーを発生させる）
        //プレイヤーに接近するー＞音を発生ー＞一定時間後「プレイヤーにのみダメージのある爆発」で即爆発する

        //プレイヤーに接近したらカウント開始（導火線に火をつける）
        Vector3 Dir = this.transform.position - player.transform.position;

        //フラグによって処理を変更
        if (boomStart)
        {
            //フラグがオンならカウント増加
            nowCount += tdt;
        }
        else if (Dir.magnitude <= boomDistance)
        {
            //効果音を鳴らし、爆発開始
            fuseAudioSource.Play();
            boomStart = true;
        }

        //爆発する時間をカウントが超過した場合
        if (boomTime <= nowCount)
        {
            //爆発エフェクトを生成し、削除（スコアアップはなし）
            //爆発エフェクトを生成
            GameObject go = Instantiate(boomObject) as GameObject;
            go.transform.position = this.transform.position;//位置を敵の位置へ移動
            go.GetComponent<EffectController>().Scale = boomScale;//大きさ変更

            //破壊
            Destroy(gameObject);
        }


        return;
    }

    private void SearchPlayer()//目標地点をBakeされている地点からランダムで選ぶ
    {
        Vector3 playerPos = player.transform.position;
        NavMesh.SamplePosition(playerPos, out navMeshHit, 5, 1);
        navMeshAgent.destination = navMeshHit.position;
    }
}
