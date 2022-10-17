using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    [Header("�V���b�g�̔��ˈʒu")]
    [SerializeField]
    private GameObject shotBullet;
    [Header("�V���b�g�ɕK�v�Ȃ���")]
    [SerializeField]
    private GameObject shotPrefab;
    [SerializeField]
    private AudioClip shotSoundClip;

    [Header("�Q�Ƃ���X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g��}��")]
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
        shotController.SetAimAimController(this.acz);
        shotController.lifeAndUI = this.lifeAndUI;

        //�e�ۂɑ��x��^����
        float shotForce = go.GetComponent<ShotController>().GetShotSpeed();
        go.GetComponent<ShotController>().ShotAddForce(shotBullet.transform.position, shotBullet.transform.forward * shotForce);

        //���ˌ��ʉ���炷
        this.GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
