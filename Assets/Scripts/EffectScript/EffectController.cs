using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{

    private float timer = 0;
    [Header("íœ‚³‚ê‚é‚Ü‚Å‚ÌŽžŠÔ")]
    [SerializeField]
    private float DeleteTime = 0;
    [HideInInspector]
    public Vector3 Scale;

    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = Scale;
    }

    // Update is called once per frame
    void Update()
    {
        float tdt = Time.deltaTime;
        //ƒJƒEƒ“ƒg‚ð‘‚â‚·
        timer += tdt;
        if (timer >= DeleteTime) //3•bŒã
        {
            //”jŠü
            Destroy(gameObject);
        }
    }
}
