using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDestroyController : MonoBehaviour
{
    [Header("移動させたいビル群")]
    public GameObject buildings;
    public float maxPosY;
    public float moveSpeedY;

    [Header("以降ビル破壊エフェクト")]
    public GameObject explosionEffect;
    [System.Serializable]
    public struct Explosion
    {
        public GameObject positionAsObject;
        public Vector3 posDifference;
        public Vector3 effectScale;
        public float bomTime;
    }
    public Explosion[] bomgo = new Explosion[1];
    private int bomNum = 0;
    private float bomTimer = 0;

    // Update is called once per frame
    void Update()
    {

        //破壊が終わったら必要ないので破壊
        if (buildings.transform.position.y <= maxPosY) { Destroy(this.GetComponent<BuildingDestroyController>()); }
        else
        {
            //エフェクトが予約されている場合
            if (bomNum < bomgo.Length)
            {
                //ビルの爆破カウント
                bomTimer += Time.deltaTime;
                if (bomgo[bomNum].bomTime <= bomTimer)
                {
                    //爆破エフェクト生成
                    Explosion ex = bomgo[bomNum];
                    GameObject go = Instantiate(explosionEffect,
                                                ex.positionAsObject.transform.position,
                                                new Quaternion(0, 0, 0, 0));
                    //位置調整およびサイズ調整
                    go.transform.position += ex.posDifference;
                    go.gameObject.GetComponent<EffectController>().Scale = ex.effectScale;
                    //カウントインクリメント
                    ++bomNum;
                }
            }

            //ビルの移動
            buildings.transform.Translate(new Vector3(0, -moveSpeedY * Time.deltaTime, 0), 0);

        }
    }
}
