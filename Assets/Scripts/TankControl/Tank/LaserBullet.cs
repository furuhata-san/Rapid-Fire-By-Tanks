using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    [Header("�V���b�g�̔��ˈʒu")]
    public GameObject shotBullet;
    [Header("�V���b�g�ɕK�v�Ȃ���")]
    public GameObject shotPrefab;
    public AudioClip shotSoundClip;

    [Header("�Q�Ƃ���X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g��}��")]
    public AimController acz;
    public LifeAndUIMgr lifeAndUI;

    [Header("���ˊԊu")]
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

    //�ˌ�
    void Fire(float tdt, GameObject Prefab, AudioClip clip)
    {
        //�K�v�ȃI�u�W�F�N�g���Ȃ������ꍇ�͏������s��Ȃ�
        if (shotBullet == null) return;
        if (shotPrefab == null) return;

        lockTimer = shotLock;

        //�e�ۂ̃v���t�@�u���R�s�[���Đ���
        GameObject go = Instantiate(Prefab) as GameObject;

        //�������ꂽ�I�u�W�F�N�g�ɓn���������̂�n��
        LaserController laserController = go.GetComponent<LaserController>();
        laserController.acz = this.acz;
        laserController.lifeAndUI = this.lifeAndUI;

        //�e�ۂɑ��x��^����
        float shotForce = go.GetComponent<LaserController>().shotSpeed;
        go.GetComponent<LaserController>().ShotAddForce(shotBullet.transform.position, shotBullet.transform.forward * shotForce);

        //���ˌ��ʉ���炷
        this.GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
