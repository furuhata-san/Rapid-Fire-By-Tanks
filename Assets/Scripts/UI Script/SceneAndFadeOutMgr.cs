using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAndFadeOutMgr : MonoBehaviour
{
    [Header("�t�F�[�h�A�E�g�}��")]
    public GameObject FadeOut;

    [Header("BGM��炵�Ă���I�[�f�B�I")]
    [SerializeField]
    private AudioSource source;

    [Header("�^�C�g���̐�Ԃ�}��")]
    [SerializeField]
    private ExitTank titleTank;



    //���ʉ���~�A�t�F�[�h�A�E�g��L�����A���V�[���̐ݒ�
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


    //���ʉ���~�A�t�F�[�h�A�E�g��L�����A��Ԕ���
    public void OnBottun_End()
    {
        if (source) source.Stop();
        FadeOut.SetActive(true);
        titleTank.ExitSelected();
    }
}
