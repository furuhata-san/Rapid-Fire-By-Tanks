using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image image;

    public float fadeInSpeed = 1.0f;
    private float fadeAlpha = 1.0f;
    


    // Start is called before the first frame update
    void Start()
    {
        image = this.gameObject.GetComponent<Image>();
        fadeAlpha = 1.0f;
        image.color = new Color(0.0f, 0.0f, 0.0f, fadeAlpha);
    }

    // Update is called once per frame
    void Update()
    {
        fadeAlpha -= Time.deltaTime * fadeInSpeed;
        image.color = new Color(0.0f, 0.0f, 0.0f, fadeAlpha);

        if(image.color.a <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
