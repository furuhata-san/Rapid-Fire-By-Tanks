using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAndFadeOutMgr : MonoBehaviour
{
    public GameObject FadeOut;


    public void OnButton_GoTitle()
    {
        FadeOut.SetActive(true);
        FadeOut.transform.Find("ShadowTank").GetComponent<ShadowTankSceneChanger>().Set_SceneName("Title");
        

    }

    public void OnBottun_GameStart()
    {
        FadeOut.SetActive(true);
        FadeOut.transform.Find("ShadowTank").GetComponent<ShadowTankSceneChanger>().Set_SceneName("Game");
    }

    public void OnBottun_Tutorial()
    {
        FadeOut.SetActive(true);
        FadeOut.transform.Find("ShadowTank").GetComponent<ShadowTankSceneChanger>().Set_SceneName("Tutorial");
    }

    public void Go_Result()
    {
        FadeOut.SetActive(true);
        FadeOut.transform.Find("ShadowTank").GetComponent<ShadowTankSceneChanger>().Set_SceneName("Result");
    }

    public void OnBottun_End()
    {
        Application.Quit();
    }
}
