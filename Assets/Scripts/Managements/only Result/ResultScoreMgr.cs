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
        //���݂̃X�R�A���R�s�[
        if (!GameObject.Find("ProjectManagement"))
        {
            Debug.LogError("�^�C�g����ʂ���Debug���J�n�����ꍇ�A�X�R�A�����U���g��ʂɈ����p�����悤�ɂȂ�܂��B");
            return;
        }
        else
        {
            scoreManagement = GameObject.Find("ProjectManagement").GetComponent<ScoreManagement>();
        }

        nowScore = scoreManagement.Get_NowScore();
        
        //�n�C�X�R�A�̔���
        if (scoreManagement.Judge_NowHighScore())
        {
            //�n�C�X�R�A�Ȃ猻�݂̃X�R�A���R�s�[
            scoreManagement.Set_HighScore(nowScore);
            //NewRecode�̃e�L�X�g��L����
            newRecodeText.gameObject.SetActive(true);
        }

        //�n�C�X�R�A�̃R�s�[
        highScore = scoreManagement.Get_HighScore();

        //�e�L�X�g�ɔ��f
        nowScoreText.text = "Score:" + nowScore.ToString();
        highScoreText.text = "High:" + highScore.ToString();
    }

}
