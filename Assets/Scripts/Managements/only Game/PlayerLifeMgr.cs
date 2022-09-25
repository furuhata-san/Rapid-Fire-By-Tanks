using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeMgr : MonoBehaviour
{
    [Header("プレイヤの体力最大値")]
    [SerializeField]
    private int lifeMax = 1;
    private float lifeNow;
    private bool dieStartFlag;//死亡時一回

    [Header("体力の回復速度（１秒間ごと）")]
    public float healSpeed;

    public float GetLifeNow() { return lifeNow; }
    public int GetLifeMax() { return lifeMax; }

    private void HealLife(float value) { 
        if (!dieStartFlag) return;
        lifeNow += value;
        if (lifeNow > lifeMax) lifeNow = lifeMax;
    }

    public void PlayerGetDamage(int damage) { lifeNow -= damage; }
    public bool JudgePlayerDie() { return lifeNow <= 0; }
    

    [Header("プレイヤ死亡時、作成するエフェクト")]
    public GameObject dieEffect;
    public Vector3 DieEffectScale;

    [Header("プレイヤ死亡時、無効化(有効化)するオブジェクト")]
    public GameObject[] stopGameObjects = new GameObject[1];
    public GameObject[] playGameObjects = new GameObject[1];
    public MonoBehaviour[] stopScripts = new MonoBehaviour[1];

    void Awake()
    {
        //ライフを最大値に
        lifeNow = (float)lifeMax;
        dieStartFlag = true;
    }

    private void Update()
    {
        HealLife(healSpeed * Time.deltaTime);
        PlayerDie(JudgePlayerDie() && dieStartFlag);
    }




    private void PlayerDie(bool flag)
    {
        if (!flag) return;
        dieStartFlag = false;
        //爆発エフェクトを自身の座標に作成
        GameObject go = Instantiate(dieEffect);
        go.transform.position = this.transform.position;
        go.GetComponent<EffectController>().Scale = DieEffectScale;//大きさ変更

        //オブジェクトを有効化（無効化）
        for (int i = 0; i < stopGameObjects.Length; ++i)
        {
            if(stopGameObjects[i] != this.gameObject)//バグ防止（プレイヤは最後に無効化）
            {
                stopGameObjects[i].SetActive(false);
            }
        }
        for (int i = 0; i < playGameObjects.Length; ++i)
        {
            playGameObjects[i].SetActive(true);
        }
        for(int i = 0; i < stopScripts.Length; ++i) 
        {
            stopScripts[i].enabled = false;
        }
    }

    //弾丸がヒットしたときのダメージ処理
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag != "EnemyAttack") return;

        //もしダメージがアタッチされていたら
        HaveDamage hc;
        if (hc = other.transform.GetComponent<HaveDamage>())
        {
            //ライフを減らす
            lifeNow -= hc.GetDamage();//スクリプト内のダメージ
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "EnemyAttack") return;

        //もしダメージがアタッチされていたら
        HaveDamage hc;
        if (hc = other.transform.GetComponent<HaveDamage>())
        {
            //ライフを減らす
            lifeNow -= hc.GetDamage();//スクリプト内のダメージ
        }
    }
}
