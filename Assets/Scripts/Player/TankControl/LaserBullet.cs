using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    [Header("���[�U�[�̔��ˈʒu")]
    [SerializeField]
    private GameObject shotBullet;
    [Header("���˂ɕK�v�Ȃ���")]
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private AudioClip laserSoundClip;

    [Header("�Q�Ƃ���X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g��}��")]
    [SerializeField]
    private AimController aim;
    [SerializeField]
    private LifeAndUIMgr lifeAndUI;

    [Header("���ˊԊu")]
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

    //�ˌ�
    void Fire(float tdt, GameObject Prefab, AudioClip clip)
    {
        //�K�v�ȃI�u�W�F�N�g���Ȃ������ꍇ�͏������s��Ȃ�
        if (shotBullet == null) return;
        if (laserPrefab == null) return;

        lockTimer = shotLock;

        //�e�ۂ̃v���t�@�u���R�s�[���Đ���
        GameObject go = Instantiate(Prefab) as GameObject;

        //�������ꂽ�I�u�W�F�N�g�ɓn���������̂�n��
        LaserController laserController = go.GetComponent<LaserController>();
        laserController.SetAimController(this.aim);
        laserController.lifeAndUI = this.lifeAndUI;

        //�e�ۂɑ��x��^����
        float shotForce = go.GetComponent<LaserController>().GetShotSpeed();
        go.GetComponent<LaserController>().ShotAddForce(shotBullet.transform.position, shotBullet.transform.forward * shotForce);

        //���ˌ��ʉ���炷
        this.GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
