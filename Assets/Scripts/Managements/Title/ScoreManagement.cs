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

    public bool Judge_NowHighScore()//ç≈çÇìæì_Çè„âÒÇ¡ÇƒÇ¢ÇΩÇÁtrue
    {
        if (highScore < nowScore)
        {
            return true;
        }
        return false;
    }

    /*
    //PCíPà Ç≈ÇÃï€ë∂ 
    if(PrayerPrefs.GetInt("RapidFireByTanks_HighScore") < nowScore){
        PrayerPrefs.SetInt("RapidFireByTanks_HighScore", nowScore);
    }
    */


}
