using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunBullet : MonoBehaviour
{
    [Header("ショットの発射位置")]
    [SerializeField]
    private GameObject shotBullet;
    [Header("ショットに必要なもの")]
    [SerializeField]
    private GameObject shotPrefab;
    [SerializeField]
    private AudioClip shotSoundClip;

    [Header("ショット発射間隔")]
    private float shotCount = 0;
    [SerializeField]
    private float shotInterval = 0.1f;

    [Header("参照するスクリプトがアタッチされているオブジェクトを挿入")]
    [SerializeField]
    private AimController aim;
    public AimController GetAimController() { return aim; }
    [SerializeField]
    private LifeAndUIMgr lifeAndUI;

    [Header("砲台の回転速度")]
    [SerializeField]
    private float bulletRotateMaxSpeed = 1080;
    [SerializeField]
    private float bulletRotateLowSpeed = 1080;
    private float bulletRotateMinusSpeed;

    private void Start()
    {
        bulletRotateMinusSpeed = bulletRotateMaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float tdt = Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            //バレット回転速度のマイナス値を０に上書き
            bulletRotateMinusSpeed = 0;
            //ショット発射間隔のカウントを増加
            shotCount += tdt;
            //インターバルで弾発射
            if (shotCount > shotInterval)
            {
                Fire(tdt, shotPrefab, shotSoundClip);
                shotCount -= shotInterval;
            }
        }
        else
        {
            //いつでも発射できるように０へ変更
            shotCount = 0;
            //バレット回転速度をゆっくり低下
            bulletRotateMinusSpeed += bulletRotateLowSpeed * tdt;
            if (bulletRotateMinusSpeed >= bulletRotateMaxSpeed)
            {
                bulletRotateMinusSpeed = bulletRotateMaxSpeed;
            }
        }

        //バレット回転
        RotateBullet((bulletRotateMaxSpeed - bulletRotateMinusSpeed) * tdt);

    }

    //射撃
    void Fire(float tdt, GameObject Prefab, AudioClip clip)
    {
        //必要なオブジェクトがなかった場合は処理を行わない
        if (shotBullet == null) return;
        if (shotPrefab == null) return;

        //弾丸のプレファブをコピーして生成
        GameObject go = Instantiate(Prefab) as GameObject;

        //生成されたオブジェクトに渡したいものを渡す
        ShotController shotController = go.GetComponent<ShotController>();
        shotController.SetAimAimController(this.aim);
        shotController.lifeAndUI = this.lifeAndUI;

        //弾丸に速度を与える
        float shotForce = go.GetComponent<ShotController>().GetShotSpeed();
        go.GetComponent<ShotController>().ShotAddForce(shotBullet.transform.position, shotBullet.transform.forward * shotForce);

        //発射効果音を鳴らす
        this.GetComponent<AudioSource>().PlayOneShot(clip);
    }

    void RotateBullet(float Speed)
    {
        transform.Rotate(new Vector3(0, 0, Speed));
    }
}
