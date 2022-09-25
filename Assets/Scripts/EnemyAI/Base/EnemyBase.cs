using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    [Header("敵の体力最大値")]
    [SerializeField]
    private int lifeMax = 1;
    private int lifeNow;
    public int GetLifeNow() { return lifeNow; }
    public int GetLifeMax() { return lifeMax; }
    public void EnemyGetDamage(int damage) { lifeNow -= damage; }
    public bool JudgeEnemyDie() { return lifeNow <= 0; }

    [Header("生成時、向きランダム")]
    public bool randomRotateRespawn;

    [Header("死亡時にならす効果音（鳴き声や機械音）")]
    public AudioSource dieAudioSource;

    [Header("加算するスコア")]
    public int score = 100;
    public ScoreAndUIMgr ScoreMgr;
    public bool firstDied = true;//trueのとき一度だけスコアを加算する

    void Awake()
    {
        //ライフを最大値に
        lifeNow = lifeMax;

        //向きランダム
        if (randomRotateRespawn)
        {
            float step = Random.Range(-360, 360);
            transform.Rotate(Vector3.up, step);
        }

        //スコアマネージャー検索
        ScoreMgr = GameObject.Find("GameManagement").GetComponent<ScoreAndUIMgr>();
    }

    //弾丸がヒットしたときのダメージ処理
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "EnemyAttack") return;

        //もしダメージがアタッチされていたら
        HaveDamage hc;
        if (hc = other.transform.GetComponent<HaveDamage>())
        {
            //ライフを減らす
            lifeNow -= hc.GetDamage();//スクリプト内のダメージ

            if (lifeNow <= 0)//ゼロ以下にならないように補正
            {
                lifeNow = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "EnemyAttack") return;

        //もしダメージがアタッチされていたら
        HaveDamage hc;
        if (hc = other.transform.GetComponent<HaveDamage>())
        {
            //ライフを減らす
            lifeNow -= hc.GetDamage();//スクリプト内のダメージ

            if (lifeNow <= 0)//ゼロ以下にならないように補正
            {
                lifeNow = 0;
            }
        }
    }
}
