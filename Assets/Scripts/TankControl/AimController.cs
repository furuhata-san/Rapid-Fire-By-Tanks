using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{
    [Header("このオブジェクトが参照するオブジェクト")]
    public Camera MainCamera;
    public GameObject ShotBullet;
    public Image aimImage;

    [Header("現在、カーソルが指している敵の情報をコピーするオブジェクト")]
    public LifeAndUIMgr[] lifeAndUI = new LifeAndUIMgr[1];

    [HideInInspector]
    public Vector3 targetPos;

    public RaycastHit msHit;
    public RaycastHit blHit;



    void Update()
    {
        // マウスの位置にRayを飛ばす。※ほかのスクリプトで使用
        Vector2 msPos = Input.mousePosition;
        Ray msRay = Camera.main.ScreenPointToRay(msPos);
        Physics.Raycast(msRay, out msHit);

        //砲台の向きにRayをとばし、ヒットするかを計算する
        Ray blRay = new Ray(ShotBullet.transform.position, ShotBullet.transform.forward);
        if (Physics.Raycast(blRay, out blHit))
        {
            // RayがColliderと衝突した地点の座標を取得
            targetPos = blHit.point - ShotBullet.transform.position;

            //ターゲットがメインカメラのどこに表示されているかを取得
            Vector2 pos2D = RectTransformUtility.WorldToScreenPoint(Camera.main, blHit.point);
            transform.position = pos2D;

            if (blHit.transform.CompareTag("Enemy"))
            {
                //体力を参照する敵を変更
                EnemyBase ebase = blHit.transform.gameObject.GetComponent<EnemyBase>();
                
                //敵の情報を別スクリプトに渡す
                for (int i = 0; i < lifeAndUI.Length; ++i)
                {
                    lifeAndUI[i].ebase = blHit.transform.gameObject.GetComponent<EnemyBase>();
                }

                if (ebase.GetLifeNow() > 0)//敵のライフがゼロ以下ではない場合
                {
                    // 照準器を赤色に変化させる。
                    aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                }
                else
                {
                    // 照準器の色は白
                    aimImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
            }
            else
            {
                // 照準器の色は白
                aimImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }
}
