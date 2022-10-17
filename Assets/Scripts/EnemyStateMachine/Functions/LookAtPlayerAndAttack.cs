using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerAndAttack : EnemyStateFunction
{
    [Header("プレイヤーの方向を向く速度")]
    public float lookSpeed;

    [Header("ショットを発射する場合はチェックを入れ、情報を入力")]
    public bool shotting = false;
    public GameObject shotPrefab;
    private float nowShotCount;
    public float shotInterval;
    public Vector3 shotStartAdjustment;
    private Transform target;

    //プレイヤーの方向へ向く
    private void LookPlayer(float tdt)
    {
        float step = lookSpeed * tdt;
        Vector3 targetDir = target.position - transform.position;
        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);
        transform.rotation = Quaternion.LookRotation(moveDir);
    }

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーを検索し、ターゲットとする
        target = GameObject.Find("PlayerTank").transform;
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        Attack(tdt);
        return EnemyStateMachine.State.Now;
    }

    void Attack(float tdt)
    {
        //プレイヤの方向を向き
        LookPlayer(tdt);
        //インターバルを増加する
        nowShotCount += tdt;

        if (shotting)//ショットを行う場合
        {
            if (nowShotCount >= shotInterval)//カウントがインターバルを超過したら
            {
                //弾丸のプレファブをコピーして生成
                GameObject go = Instantiate(shotPrefab);

                //生成されたオブジェクトに渡したいものを渡す
                EnemyShotController shotController = go.GetComponent<EnemyShotController>();
                shotController.targetPosition = target.transform.position;//ターゲット座標を設定

                //弾丸に速度を与える
                float shotForce = shotController.GetShotSpeed();
                shotController.ShotAddForce(this.transform.position + shotStartAdjustment, this.transform.forward * shotForce);

                //カウントを減少
                nowShotCount -= shotInterval;

                //発射効果音を鳴らす
                //this.GetComponent<AudioSource>().PlayOneShot(clip);
            }
        }
    }
}
