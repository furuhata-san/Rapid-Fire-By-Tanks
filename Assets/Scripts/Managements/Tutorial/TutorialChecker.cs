using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialChecker : MonoBehaviour
{
    [Header("����")]
    public string memo;
    //�t���O�Ǘ�
    public bool flag;
    public void SetFlag(bool fl) { flag = fl; }
    public bool GetFlag() { return flag; }

    //�ȉ�����
    [Header("�I�u�W�F�N�g���j�󂳂�Ă��邩�𔻒�")]
    public bool DestroyObjectJudge;
    public GameObject go;
    private bool DestroyObjectChecker()
    {
        //�������s��Ȃ��ꍇ�AFalse��Ԃ�
        if (!DestroyObjectJudge) return false;
        //�I�u�W�F�N�g���Ȃ��ꍇtrue��Ԃ�
        return !go;
    }
    // Start �Ɓ@Update ///////////////////////////////////////////////////
    private void Start()
    {
        //�I�u�W�F�N�g�������Ă�����L����
        if (go) go.SetActive(true);
    }

    private void Update()
    {
        if (DestroyObjectJudge) flag = DestroyObjectChecker();
    }

}
