using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickEffectMgr : MonoBehaviour
{
    [Header("�J�[�\��Image��Hierarchy���玝���Ă���")]
    [SerializeField]
    private Image cursorImage;

    [Header("��������Image��Prefab")]
    [SerializeField]
    private Image imagePrefab;

    [Header("�e�I�u�W�F�N�g�ƂȂ�Canvas")]
    [SerializeField]
    private Canvas canvas;

    [Header("�t�F�[�h�A�E�g���̓J�[�\����\���i�Ȃ��Ă��j")]
    [SerializeField]
    private GameObject fadeOut;

    // Update is called once per frame
    void Update()
    {
        //�t�F�[�h���Q�Ƃ���Ă���
        if (fadeOut)
        {
            //�t�F�[�h��
            if (fadeOut.activeSelf == true)
            {
                //�J�[�\���C���[�W������
                cursorImage.gameObject.SetActive(false);
            }
            else
            {
                //�J�[�\���̈ʒu�ύX
                cursorImage.transform.position = Input.mousePosition;
                //�G�t�F�N�g����
                CreateEffect();
            }
        }
        //�t�F�[�h���Q�Ƃ���Ă��Ȃ�
        else
        {
            //�J�[�\���̈ʒu�ύX
            cursorImage.transform.position = Input.mousePosition;
            //�G�t�F�N�g����
            CreateEffect();
        }
    }

    private void CreateEffect()
    {
        //�N���b�N���ɃG�t�F�N�g����
        if (Input.GetMouseButtonDown(0))
        {
            Image eff = Instantiate(imagePrefab);
            eff.transform.SetParent(canvas.transform);
            eff.transform.position = cursorImage.transform.position;
        }
    }
}
