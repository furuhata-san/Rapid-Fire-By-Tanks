using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagement : MonoBehaviour
{
    private int highScore = 0;
    public int nowScore = 0;

    public void Set_NowScore(int score)
    {
        nowScore = score;
    }

    public int Get_NowScore()
    {
        return nowScore;
    }

    public void Set_HighScore(int score)
    {
        highScore = score;
    }

    public int Get_HighScore()
    {
        return highScore;
    }

    public bool Judge_NowHighScore()//最高得点を上回っていたらtrue
    {
        if (highScore < nowScore)
        {
            return true;
        }
        return false;
    }

    /*
    //PC単位での保存 
    if(PrayerPrefs.GetInt("RapidFireByTanks_HighScore") < nowScore){
        PrayerPrefs.SetInt("RapidFireByTanks_HighScore", nowScore);
    }
    */


}
