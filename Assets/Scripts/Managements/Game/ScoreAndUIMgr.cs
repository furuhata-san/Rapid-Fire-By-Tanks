using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndUIMgr : MonoBehaviour
{
    [Header("�X�R�A�e�L�X�g")]
    public Text scoreText;

    [Header("�X�R�A�ő�l")]
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
            Debug.LogError("�^�C�g����ʂ���Debug���J�n�����ꍇ�A���̃G���[�͏o�����܂���.");
        }
        else
        {
            scoreManagement = GameObject.Find("ProjectManagement").GetComponent<ScoreManagement>();
        }
    }
        

    // Update is called once per frame
    void Update()
    {
        //�f�o�b�O�R�[�h
        if (Input.GetKeyDown(KeyCode.F7)) { NowScore += 5000; }
        else if (Input.GetKeyDown(KeyCode.F8)) { NowScore -= 5000; }

        //�X�R�A�ő�l�ȏ�̏ꍇ�A�␳
        if (MaxScore < NowScore)
        {
            NowScore = MaxScore;
        }
        else if(NowScore < 0)   //�X�R�A���O�����̏ꍇ���␳
        {
            NowScore = 0;
        }

        //�X�R�A�e�L�X�g�X�V
        scoreText.text = "Score:" + NowScore;

        //���݂̃X�R�A�����Ȃ��I�u�W�F�N�g�֓n��
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
