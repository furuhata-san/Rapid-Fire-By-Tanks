using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextboxControl : MonoBehaviour
{
    private bool flag = true;
    private bool moveState = false;

    private float ScaleX = 0.0f;

    public float Speedx;
    public AudioClip clip;

    private void Start()
    {
        flag = true;
        moveState = false;
        ScaleX = 0.0f;
    }

    private void Update()
    {
        if (flag)
        {
            //trueÇ»ÇÁèkÇﬂÇÈÅAfalseÇ»ÇÁçLÇ∞ÇÈ
            if (moveState)
            {
                ScaleX -= Time.deltaTime * Speedx;
                if (ScaleX <= 0.0f) { ScaleX = 0.0f; moveState = false; }
            }
            else
            {
                ScaleX += Time.deltaTime * Speedx;
                if (ScaleX >= 1.0f) { ScaleX = 1.0f; flag = false; }
            }
        }

        //ëÂÇ´Ç≥ÇìKóp
        transform.localScale = new Vector3(ScaleX, 1.0f, 1.0f);
    }

    public void SetFlag(bool flag_)
    {
        flag = flag_;
        moveState = flag_;
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

}
