using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialChecker : MonoBehaviour
{
    [Header("メモ")]
    public string memo;
    //フラグ管理
    public bool flag;
    public void SetFlag(bool fl) { flag = fl; }
    public bool GetFlag() { return flag; }

    //以下処理
    [Header("オブジェクトが破壊されているかを判定")]
    public bool DestroyObjectJudge;
    public GameObject go;
    private bool DestroyObjectChecker()
    {
        //処理を行わない場合、Falseを返す
        if (!DestroyObjectJudge) return false;
        //オブジェクトがない場合trueを返す
        return !go;
    }
    // Start と　Update ///////////////////////////////////////////////////
    private void Start()
    {
        //オブジェクトが入っていたら有効化
        if (go) go.SetActive(true);
    }

    private void Update()
    {
        if (DestroyObjectJudge) flag = DestroyObjectChecker();
    }

}
