using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FollowTheEnemy : MonoBehaviour
{
    [Header("このオブジェクトにアタッチされている体力管理のマネージャー")]
    public LifeAndUIMgr LUM;

    //参照するエネミー
    private EnemyBase ebase;


    // Start is called before the first frame update
    void Start()
    {
        //最初は画面外
        transform.position = new Vector2(-2000, -2000);
    }

    // Update is called once per frame
    void Update()
    {
        ebase = LUM.ebase;
        //敵が存在しいている場合、体力を表示
        if (ebase)
        {
            // プレイヤーのスクリーン座標（2D）を取得
            Vector3 screen = RectTransformUtility.WorldToScreenPoint(Camera.main, ebase.transform.position);
            // 表示物より少し上にゲージが表示されるようにする
            float up = 100;
            // ゲージの座標を設定
            Vector3 trans = this.gameObject.transform.position;
            trans.x = screen.x;
            trans.y = screen.y + up;
            this.gameObject.transform.position = trans;
        }
        else
        {
            //画面外
            transform.position = new Vector2(-2000, -2000);
        }
    }
}
