using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCanonController : MonoBehaviour
{
    [Header("振り向き速度")]
    [SerializeField]
    private float speed;
    private float step;

    public void TankCanonMove(Vector3 target)
    {        
        //速度計算（deltaTime）
        step = speed * Time.deltaTime;

        //自身から見て、ターゲットがどこの位置にあるか
        Vector3 targetDir = target - transform.position;

        //設定した速度で補正しながら砲台の回転量を求める
        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);

        //回転
        transform.rotation = Quaternion.LookRotation(moveDir);
    }
}
