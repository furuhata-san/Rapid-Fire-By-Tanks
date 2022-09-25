using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeBoomController : MonoBehaviour
{
    [Header("爆発攻撃（着弾時即座に生成するオブジェクト）")]
    public GameObject DestroyEffect;
    public Vector3 DieEffectScale;
    public int damage;

    [Header("隕石の生成する高さを乱数で加算しずらす")]
    public Vector2 createPosYPlas;


    private void Start()
    {
        float randomNum = Random.Range(createPosYPlas.x, createPosYPlas.y);
        Vector3 thisDefPos = transform.position;
        this.transform.position = new Vector3(thisDefPos.x, thisDefPos.y + randomNum, thisDefPos.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Wall") return;

        //爆発エフェクトを生成
        GameObject go = Instantiate(DestroyEffect) as GameObject;
        go.transform.position = this.transform.position;//位置を自身の位置へ移動
        go.GetComponent<EffectController>().Scale = DieEffectScale;//大きさ変更

        //破壊
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Wall") return;

        //爆発エフェクトを生成
        GameObject go = Instantiate(DestroyEffect) as GameObject;
        go.transform.position = this.transform.position;//位置を自身の位置へ移動
        go.GetComponent<EffectController>().Scale = DieEffectScale;//大きさ変更
        //破壊
        Destroy(gameObject);
    }

}
