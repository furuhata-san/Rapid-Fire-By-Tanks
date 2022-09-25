using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [Header("ショットの初速")]
    public float shotSpeed;
    private float step;
    [Header("ヒットエフェクトのサイズ")]
    public GameObject hitEffect;
    public Vector3 EffectScale;
    [HideInInspector]
    public AimController acz;
    private Vector3 targetPosition;

    [HideInInspector]
    public LifeAndUIMgr lifeAndUI;

    public void ShotAddForce(Vector3 position, Vector3 Force)
    {
        this.transform.position = position;
        GetComponent<Rigidbody>().AddForce(Force);
    }

    private void OnCollisionEnter(Collision other)
    {
        //ヒットしたコライダーのタグがプレイヤーかショットだった場合、処理なし
        if (other.transform.tag == "Player") return;
        if (other.transform.tag == "Shot") return;

        //ヒットしたのであれば
        //ヒットエフェクト生成
        if (hitEffect)
        {
            GameObject go = Instantiate(hitEffect) as GameObject;
            go.GetComponent<EffectController>().Scale = this.EffectScale;
            go.transform.position = this.transform.position;
        }
        if (other.transform.tag == "Enemy")
        {
            //体力ゲージの対象となる敵を変更
            lifeAndUI.ebase = other.gameObject.GetComponent<EnemyBase>();
        }
        //オブジェクトを破壊
        Destroy(gameObject);
    }

    private void Start()
    {
        targetPosition = acz.blHit.point;
        step = shotSpeed * Time.deltaTime;
        Vector3 targetDir = targetPosition - transform.position;
        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);
        transform.rotation = Quaternion.LookRotation(moveDir);
    }
}
