using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndUIMgr : MonoBehaviour
{
    [Header("スコアテキスト")]
    public Text scoreText;

    [Header("スコア最大値")]
    public int MaxScore;
    [HideInInspector]
    public int NowScore;

    ScoreManagement scoreManagement;

    // Start is called before the first frame update
    void Start()
    {
        NowScore = 0;
        if (!GameObject.Find("ProjectManagement"))
        {
            Debug.LogError("タイトル画面からDebugを開始した場合、このエラーは出現しません.");
        }
        else
        {
            scoreManagement = GameObject.Find("ProjectManagement").GetComponent<ScoreManagement>();
        }
    }
        

    // Update is called once per frame
    void Update()
    {
        //デバッグコード
        if (Input.GetKeyDown(KeyCode.F7)) { NowScore += 5000; }
        else if (Input.GetKeyDown(KeyCode.F8)) { NowScore -= 5000; }

        //スコア最大値以上の場合、補正
        if (MaxScore < NowScore)
        {
            NowScore = MaxScore;
        }
        else if(NowScore < 0)   //スコアが０未満の場合も補正
        {
            NowScore = 0;
        }

        //スコアテキスト更新
        scoreText.text = "Score:" + NowScore;

        //現在のスコアを壊れないオブジェクトへ渡す
        if(scoreManagement) scoreManagement.Set_NowScore(NowScore);

        
    }

    public void AddScore(int score)
    {
        NowScore += score;
    }

    public int GetNowScore()
    {
        return NowScore;
    }

}
