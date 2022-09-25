using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //物理演算
    private Rigidbody rigid;

    [Header("参照するスクリプトがアタッチされているオブジェクトを挿入")]
    public TankHeadController thc;
    public TankCanonController tcc;
    public AimController acz;

    [Header("プレイヤーの動作の速度調整")]
    public float rotateForce;
    public float runSpeed;
    public float maxSpeed;

    //前進後退
    void Run(float tdt)
    {
        float key_ud = Input.GetAxis("Vertical");
        Vector3 vel_xz = new Vector3(rigid.velocity.x, 0, rigid.velocity.z);
        //入力が行われているかつ最高速度でなければ移動
        if (key_ud > 0.01f || key_ud < -0.01f)
        {
            if (vel_xz.magnitude < maxSpeed)
            {
                rigid.AddForce(transform.forward * Input.GetAxis("Vertical") * runSpeed * tdt);
            }
        }
    }

    //回転
    void turn(float tdt)
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateForce * tdt, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //物理演算がされていない場合は処理を行わない
        if (rigid == null) return;

        //前回のフレームとの時間差を取得
        float tdt = Time.deltaTime;

        //マウスの現在位置を取得
        Vector3 MousePos = acz.msHit.point;
        
        //砲台回転
        thc.TankHeadMove(MousePos);

        //砲口回転
        tcc.TankCanonMove(MousePos);

        //入力によってプレイヤをY軸回転
        turn(tdt);

        //前進後退
        Run(tdt);
    }
}
