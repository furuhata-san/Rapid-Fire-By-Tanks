using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunBullet : MonoBehaviour
{
    [Header("�V���b�g�̔��ˈʒu")]
    public GameObject shotBullet;
    [Header("�V���b�g�ɕK�v�Ȃ���")]
    public GameObject shotPrefab;
    public AudioClip shotSoundClip;

    [Header("�V���b�g���ˊԊu")]
    private float shotCount = 0;
    [SerializeField]
    private float shotInterval = 0.1f;

    [Header("�Q�Ƃ���X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g��}��")]
    public AimController acz;
    public LifeAndUIMgr lifeAndUI;

    [Header("�C��̉�]���x")]
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
            //�o���b�g��]���x�̃}�C�i�X�l���O�ɏ㏑��
            bulletRotateMinusSpeed = 0;
            //�V���b�g���ˊԊu�̃J�E���g�𑝉�
            shotCount += tdt;
            //�C���^�[�o���Œe����
            if (shotCount > shotInterval)
            {
                Fire(tdt, shotPrefab, shotSoundClip);
                shotCount = 0;
            }
        }
        else
        {
            //���ł����˂ł���悤�ɂO�֕ύX
            shotCount = 0;
            //�o���b�g��]���x���������ቺ
            bulletRotateMinusSpeed += bulletRotateLowSpeed * tdt;
            if (bulletRotateMinusSpeed >= bulletRotateMaxSpeed)
            {
                bulletRotateMinusSpeed = bulletRotateMaxSpeed;
            }
        }

        //�o���b�g��]
        RotateBullet((bulletRotateMaxSpeed - bulletRotateMinusSpeed) * tdt);

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

    void RotateBullet(float Speed)
    {
        transform.Rotate(new Vector3(0, 0, Speed));
    }
}
