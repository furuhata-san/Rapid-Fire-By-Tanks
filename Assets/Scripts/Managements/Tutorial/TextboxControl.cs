using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxControl : MonoBehaviour
{
    private bool flag = true;
    private bool moveState = false;

    

    [Header("�e�L�X�g�{�̂ƃ{�b�N�X��RectTranceform"), SerializeField]
    private RectTransform boxRect;
    private Vector2 boxFirstSize;
    [SerializeField]
    private RectTransform textRect;
    private Vector2 textFirstSize;

    [Header("�e�L�X�g�{�b�N�X�̃T�C�Y�ύX���x�ƌ��ʉ�")]
    public float ScalerSpeed;
    private float Scaler = 0.0f;

    public AudioClip clip;

    private void Start()
    {
        flag = true;
        moveState = false;
        boxFirstSize = boxRect.localScale;
        textFirstSize = textRect.localScale;
        Scaler = 1.0f;
    }

    private void Update()
    {
        if (flag)
        {
            //true�Ȃ�k�߂�Afalse�Ȃ�L����
            if (moveState)
            {
                Scaler -= Time.deltaTime * ScalerSpeed;
                if (Scaler <= 0.0f) { Scaler = 0.0f; moveState = false; }
            }
            else
            {
                Scaler += Time.deltaTime * ScalerSpeed;
                if (Scaler >= 1.0f) { Scaler = 1.0f; flag = false; }
            }
        }

        //�傫����K�p
        boxRect.localScale = boxFirstSize * Scaler;
        textRect.localScale = textFirstSize * Scaler;
    }

    public void SetFlag(bool flag_)
    {
        flag = flag_;
        moveState = flag_;
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

}