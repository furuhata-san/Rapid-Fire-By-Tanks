using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAndFadeOutMgr : MonoBehaviour
{
    [Header("フェードアウト挿入")]
    public GameObject FadeOut;

    [Header("BGMを鳴らしているオーディオ")]
    [SerializeField]
    private AudioSource source;

    [Header("タイトルの戦車を挿入")]
    [SerializeField]
    private ExitTank titleTank;



    //効果音停止、フェードアウトを有効化、次シーンの設定
    public void OnButton_GoTitle()
    {
        if (source) source.Stop();
        FadeOut.SetActive(true);
        FadeOut.transform.Find("ShadowTank").GetComponent<ShadowTankSceneChanger>().Set_SceneName("Title");
    }

    public void OnBottun_GameStart()
    {
        if (source) source.Stop();
        FadeOut.SetActive(true);
        FadeOut.transform.Find("ShadowTank").GetComponent<ShadowTankSceneChanger>().Set_SceneName("Game");
    }

    public void OnBottun_Tutorial()
    {
        if (source) source.Stop();
        FadeOut.SetActive(true);
        FadeOut.transform.Find("ShadowTank").GetComponent<ShadowTankSceneChanger>().Set_SceneName("Tutorial");
    }

    public void Go_Result()
    {
        if (source) source.Stop();
        FadeOut.SetActive(true);
        FadeOut.transform.Find("ShadowTank").GetComponent<ShadowTankSceneChanger>().Set_SceneName("Result");
    }


    //効果音停止、フェードアウトを有効化、戦車爆発
    public void OnBottun_End()
    {
        if (source) source.Stop();
        FadeOut.SetActive(true);
        titleTank.ExitSelected();
    }
}
