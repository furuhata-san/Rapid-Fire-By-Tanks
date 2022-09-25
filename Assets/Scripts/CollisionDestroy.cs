using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{

    private Collider cor;
    private float destroyTime;
    private float timer = 0;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= destroyTime)
        {
            Destroy(cor);
        }
    }
}
