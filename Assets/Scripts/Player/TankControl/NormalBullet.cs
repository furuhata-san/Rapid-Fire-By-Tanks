using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    [Header("ショットの発射位置")]
    [SerializeField]
    private GameObject shotBullet;
    [Header("ショットに必要なもの")]
    [SerializeField]
    private GameObject shotPrefab;
    [SerializeField]
    private AudioClip shotSoundClip;

    [Header("参照するスクリプトがアタッチされているオブジェクトを挿入")]
    [SerializeField]
    private AimController acz;
    [SerializeField]
    private LifeAndUIMgr lifeAndUI;

    // Update is called once per frame
    void Update()
    {
        float tdt = Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
            Fire(tdt, shotPrefab, shotSoundClip);
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
        shotController.SetAimAimController(this.acz);
        shotController.lifeAndUI = this.lifeAndUI;

        //弾丸に速度を与える
        float shotForce = go.GetComponent<ShotController>().GetShotSpeed();
        go.GetComponent<ShotController>().ShotAddForce(shotBullet.transform.position, shotBullet.transform.forward * shotForce);

        //発射効果音を鳴らす
        this.GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
