using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHeadController : MonoBehaviour
{
    [Header("回転速度")]
    [SerializeField]
    private float speed;
    private float step;

    public void TankHeadMove(Vector3 target)
    {
        //Y軸の回転はなし（砲台に一任）
        target.y = transform.position.y;
        
        //移動速度を求める（deltaTime）
        step = speed * Time.deltaTime;

        //ターゲットが自身からどこの位置にいるかを計算
        Vector3 targetDir = target - transform.position;

        //求めた情報を使用して回転量を計算
        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);
        
        //回転
        transform.rotation = Quaternion.LookRotation(moveDir);
    }
}
