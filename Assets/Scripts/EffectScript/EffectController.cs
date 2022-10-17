using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{

    private float timer = 0;
    [Header("�폜�����܂ł̎���")]
    [SerializeField]
    private float DeleteTime = 0;
    [Header("�T�C�Y")]
    public Vector3 Scale;

    
    // Start is called before the first frame update
    void Start()
    {
        if(Scale != Vector3.zero)
        {
            this.transform.localScale = Scale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float tdt = Time.deltaTime;
        //�J�E���g�𑝂₷
        timer += tdt;
        if (timer >= DeleteTime)
        {
            //�j��
            Destroy(gameObject);
        }
    }
}
