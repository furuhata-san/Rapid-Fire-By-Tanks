using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxControl : MonoBehaviour
{
    private bool flag = true;
    private bool moveState = false;

    

    [Header("テキスト本体とボックスのRectTranceform"), SerializeField]
    private RectTransform boxRect;
    private Vector2 boxFirstSize;
    [SerializeField]
    private RectTransform textRect;
    private Vector2 textFirstSize;

    [Header("テキストボックスのサイズ変更速度と効果音")]
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
            //trueなら縮める、falseなら広げる
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

        //大きさを適用
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