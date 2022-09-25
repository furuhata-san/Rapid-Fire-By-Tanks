using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour
{
    [Header("ショットの初速")]
    [SerializeField]
    private float shotSpeed;
    public float GetShotSpeed()
    {
        return shotSpeed;
    }
    private float step; //移動速度（Time.deltaTime適用後）
    [Header("ヒットエフェクトのサイズ")]
    [SerializeField]
    private GameObject hitEffect;
    [SerializeField]
    private Vector3 normalEffectScale;//通常スケール
    [SerializeField]
    private Vector3 hitPlayerEffectScale;//プレイヤヒットスケール
    [HideInInspector]
    public Vector3 targetPosition;//ターゲットの位置、ショットを飛ばす方向を指定

    public void ShotAddForce(Vector3 position, Vector3 Force)
    {
        this.transform.position = position;
        GetComponent<Rigidbody>().AddForce(Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        //ヒットしたコライダーのタグがショットだった場合、処理なし
        if (other.transform.tag == "Enemy") return;
        if (other.transform.tag == "EnemyAttack") return;

        //ヒットしたのであれば
        //ヒットエフェクト生成
        if (hitEffect)
        {
            Vector3 size;//ヒットしたオブジェクトによってエフェクトサイズを変更
            if (other.transform.tag == "Player")
            {
                size = this.hitPlayerEffectScale;
            }
            else
            {
                size = this.normalEffectScale;
            }

            GameObject go = Instantiate(hitEffect) as GameObject;
            go.GetComponent<EffectController>().Scale = size;
            go.transform.position = this.transform.position;
        }

        //オブジェクトを破壊
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //ターゲットの方向へ弾を向ける
        Vector3 targetDir = targetPosition - transform.position;
        step = shotSpeed * Time.deltaTime;
        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);
        transform.rotation = Quaternion.LookRotation(moveDir);
    }

}
