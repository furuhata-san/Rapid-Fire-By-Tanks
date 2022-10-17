using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScoreMgr : MonoBehaviour
{
    private ScoreManagement scoreManagement;
    public Text newRecodeText;
    public Text nowScoreText;
    public Text highScoreText;
    private int nowScore;
    private int highScore;

    // Start is called before the first frame update
    void Start()
    {
        //現在のスコアをコピー
        if (!GameObject.Find("ProjectManagement"))
        {
            Debug.LogError("タイトル画面からDebugを開始した場合、スコアがリザルト画面に引き継がれるようになります。");
            return;
        }
        else
        {
            scoreManagement = GameObject.Find("ProjectManagement").GetComponent<ScoreManagement>();
        }

        nowScore = scoreManagement.Get_NowScore();
        
        //ハイスコアの判定
        if (scoreManagement.Judge_NowHighScore())
        {
            //ハイスコアなら現在のスコアをコピー
            scoreManagement.Set_HighScore(nowScore);
            //NewRecodeのテキストを有効化
            newRecodeText.gameObject.SetActive(true);
        }

        //ハイスコアのコピー
        highScore = scoreManagement.Get_HighScore();

        //テキストに反映
        nowScoreText.text = "Score:" + nowScore.ToString();
        highScoreText.text = "High:" + highScore.ToString();
    }

}
