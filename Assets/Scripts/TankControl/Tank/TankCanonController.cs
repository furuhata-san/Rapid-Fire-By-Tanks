using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCanonController : MonoBehaviour
{
    public float speed;
    private float step;

    public void TankCanonMove(Vector3 target)
    {        
        step = speed * Time.deltaTime;

        Vector3 targetDir = target - transform.position;

        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);

        transform.rotation = Quaternion.LookRotation(moveDir);
    }
}
