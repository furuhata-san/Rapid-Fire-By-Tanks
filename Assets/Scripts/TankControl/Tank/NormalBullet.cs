using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    [Header("�V���b�g�̔��ˈʒu")]
    public GameObject shotBullet;
    [Header("�V���b�g�ɕK�v�Ȃ���")]
    public GameObject shotPrefab;
    public AudioClip shotSoundClip;

    [Header("�Q�Ƃ���X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g��}��")]
    public AimController acz;
    public LifeAndUIMgr lifeAndUI;

    // Update is called once per frame
    void Update()
    {
        float tdt = Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
            Fire(tdt, shotPrefab, shotSoundClip);
    }

    //�ˌ�
    void Fire(float tdt, GameObject Prefab, AudioClip clip)
    {
        //�K�v�ȃI�u�W�F�N�g���Ȃ������ꍇ�͏������s��Ȃ�
        if (shotBullet == null) return;
        if (shotPrefab == null) return;

        //�e�ۂ̃v���t�@�u���R�s�[���Đ���
        GameObject go = Instantiate(Prefab) as GameObject;

        //�������ꂽ�I�u�W�F�N�g�ɓn���������̂�n��
        ShotController shotController = go.GetComponent<ShotController>();
        shotController.acz = this.acz;
        shotController.lifeAndUI = this.lifeAndUI;

        //�e�ۂɑ��x��^����
        float shotForce = go.GetComponent<ShotController>().shotSpeed;
        go.GetComponent<ShotController>().ShotAddForce(shotBullet.transform.position, shotBullet.transform.forward * shotForce);

        //���ˌ��ʉ���炷
        this.GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
