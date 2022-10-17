using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTank : MonoBehaviour
{
    public float RotateSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, RotateSpeed * Time.deltaTime, 0);
    }
}
