using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingCoolText : MonoBehaviour
{
    [Header("“_–Å‚ÌÛ‚Ì“§–¾“x‚ÆŽžŠÔ")]
    [Range(0.0f, 1.0f)]
    public float blinkingTrue;
    [Range(0.0f, 1.0f)]
    public float blinkingFalse;
    [SerializeField]
    private float inTime = 0.01f;
    [SerializeField]
    private float outTime = 0.01f;
    [SerializeField]
    private float offTime = 1.0f;

    private float blinkingTimer = 0;
    private float offTimer = 0;
    private bool alphaFlag = true;

    // Update is called once per frame
    void Update()
    {

        blinkingTimer += Time.deltaTime;
        offTimer += Time.deltaTime;


        if (alphaFlag)
        {
            if (blinkingTimer >= outTime)
            {
                blinkingTimer = 0;

                //“§–¾‚É
                alphaFlag = false;
                this.gameObject.GetComponent<Image>().color =
                    new Color(255f, 255f, 255f, blinkingFalse);
            }
        }
        else
        {
            if (blinkingTimer >= inTime)
            {
                blinkingTimer = 0;

                //ŽÀ‘Ì‰»
                alphaFlag = true;
                this.gameObject.GetComponent<Image>().color =
                    new Color(255f, 255f, 255f, blinkingTrue);
            }
        }

        if (offTimer >= offTime)
        {
            blinkingTimer = 0;
            offTimer = 0;
            alphaFlag = true;
            //ŽÀ‘Ì‰»
            this.gameObject.GetComponent<Image>().color =
                new Color(255f, 255f, 255f, blinkingTrue);
            this.gameObject.SetActive(false);
        }
    }
}
