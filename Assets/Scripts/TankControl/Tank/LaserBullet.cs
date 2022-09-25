using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    [Header("ショットの発射位置")]
    public GameObject shotBullet;
    [Header("ショットに必要なもの")]
    public GameObject shotPrefab;
    public AudioClip shotSoundClip;

    [Header("参照するスクリプトがアタッチされているオブジェクトを挿入")]
    public AimController acz;
    public LifeAndUIMgr lifeAndUI;

    [Header("発射間隔")]
    public float shotLock;
    private float lockTimer = 0;

    // Update is called once per frame
    void Update()
    {
        float tdt = Time.deltaTime;
        lockTimer -= tdt;

        if (lockTimer <= 0)
        {
            if (Input.GetMouseButton(0))
                Fire(tdt, shotPrefab, shotSoundClip);
        }
    }

    //射撃
    void Fire(float tdt, GameObject Prefab, AudioClip clip)
    {
        //必要なオブジェクトがなかった場合は処理を行わない
        if (shotBullet == null) return;
        if (shotPrefab == null) return;

        lockTimer = shotLock;

        //弾丸のプレファブをコピーして生成
        GameObject go = Instantiate(Prefab) as GameObject;

        //生成されたオブジェクトに渡したいものを渡す
        LaserController laserController = go.GetComponent<LaserController>();
        laserController.acz = this.acz;
        laserController.lifeAndUI = this.lifeAndUI;

        //弾丸に速度を与える
        float shotForce = go.GetComponent<LaserController>().shotSpeed;
        go.GetComponent<LaserController>().ShotAddForce(shotBullet.transform.position, shotBullet.transform.forward * shotForce);

        //発射効果音を鳴らす
        this.GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
