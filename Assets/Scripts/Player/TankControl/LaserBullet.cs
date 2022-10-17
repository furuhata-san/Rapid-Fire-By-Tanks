using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    [Header("レーザーの発射位置")]
    [SerializeField]
    private GameObject shotBullet;
    [Header("発射に必要なもの")]
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private AudioClip laserSoundClip;

    [Header("参照するスクリプトがアタッチされているオブジェクトを挿入")]
    [SerializeField]
    private AimController aim;
    [SerializeField]
    private LifeAndUIMgr lifeAndUI;

    [Header("発射間隔")]
    [SerializeField]
    private float shotLock;
    private float lockTimer = 0;

    // Update is called once per frame
    void Update()
    {
        float tdt = Time.deltaTime;
        lockTimer -= tdt;

        if (lockTimer <= 0)
        {
            if (Input.GetMouseButton(0))
                Fire(tdt, laserPrefab, laserSoundClip);
        }
    }

    //射撃
    void Fire(float tdt, GameObject Prefab, AudioClip clip)
    {
        //必要なオブジェクトがなかった場合は処理を行わない
        if (shotBullet == null) return;
        if (laserPrefab == null) return;

        lockTimer = shotLock;

        //弾丸のプレファブをコピーして生成
        GameObject go = Instantiate(Prefab) as GameObject;

        //生成されたオブジェクトに渡したいものを渡す
        LaserController laserController = go.GetComponent<LaserController>();
        laserController.SetAimController(this.aim);
        laserController.lifeAndUI = this.lifeAndUI;

        //弾丸に速度を与える
        float shotForce = go.GetComponent<LaserController>().GetShotSpeed();
        go.GetComponent<LaserController>().ShotAddForce(shotBullet.transform.position, shotBullet.transform.forward * shotForce);

        //発射効果音を鳴らす
        this.GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
