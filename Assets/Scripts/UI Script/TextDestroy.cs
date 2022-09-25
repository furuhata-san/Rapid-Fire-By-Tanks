using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDestroy : MonoBehaviour
{
    [SerializeField]
    private float destroyTime = 0;
    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
