using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCreate : MonoBehaviour
{
    [Header("ボス生成時テキスト")]
    public GameObject createText;

    private ScoreAndUIMgr sau;

    [System.Serializable]
    public struct Boss
    {
        public GameObject Prefab;
        public Vector3 pos;
        public Quaternion ang;
        public int createScore;
        public bool createFlag;
        public BuildingDestroyController bdc;
    }
    [Header("ボスオブジェクトスコア、呼び出すかのフラグ(trueでオン)を設定（ボスはフィールドに１体のみ生成）")]
    public Boss[] boss = new Boss[1];
    private int createdNum = 0;
    private GameObject bossLive;

    // Start is called before the first frame update
    void Start()
    {
        sau = this.gameObject.GetComponent<ScoreAndUIMgr>();
        createdNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ボスが生成できる状態であれば
        if (createdNum < boss.Length)
        {
            if (boss[createdNum].createFlag)
            {
                //スコアが生成条件を満たしていたら
                if (sau.GetNowScore() >= boss[createdNum].createScore)
                {
                    //ボスが存在しない場合
                    if (!bossLive)
                    {

                        //ボス生成
                        GameObject go = Instantiate(boss[createdNum].Prefab,
                                                    boss[createdNum].pos,
                                                    boss[createdNum].ang);
                        //ボス保存
                        bossLive = go;
                        
                        //壊すべきビルがある場合
                        if (boss[createdNum].bdc)
                            boss[createdNum].bdc.enabled = true;

                        //テキスト生成
                        createText.SetActive(true);

                        //生成できないようにフラグをオフに(一応)
                        boss[createdNum].createFlag = false;
                        //ナンバーを変更
                        ++createdNum;
                    }                }
            }

        }
    }
}
