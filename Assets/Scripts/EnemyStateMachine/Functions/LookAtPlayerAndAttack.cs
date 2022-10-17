using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerAndAttack : EnemyStateFunction
{
    [Header("�v���C���[�̕������������x")]
    public float lookSpeed;

    [Header("�V���b�g�𔭎˂���ꍇ�̓`�F�b�N�����A�������")]
    public bool shotting = false;
    public GameObject shotPrefab;
    private float nowShotCount;
    public float shotInterval;
    public Vector3 shotStartAdjustment;
    private Transform target;

    //�v���C���[�̕����֌���
    private void LookPlayer(float tdt)
    {
        float step = lookSpeed * tdt;
        Vector3 targetDir = target.position - transform.position;
        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);
        transform.rotation = Quaternion.LookRotation(moveDir);
    }

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[���������A�^�[�Q�b�g�Ƃ���
        target = GameObject.Find("PlayerTank").transform;
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        Attack(tdt);
        return EnemyStateMachine.State.Now;
    }

    void Attack(float tdt)
    {
        //�v���C���̕���������
        LookPlayer(tdt);
        //�C���^�[�o���𑝉�����
        nowShotCount += tdt;

        if (shotting)//�V���b�g���s���ꍇ
        {
            if (nowShotCount >= shotInterval)//�J�E���g���C���^�[�o���𒴉߂�����
            {
                //�e�ۂ̃v���t�@�u���R�s�[���Đ���
                GameObject go = Instantiate(shotPrefab);

                //�������ꂽ�I�u�W�F�N�g�ɓn���������̂�n��
                EnemyShotController shotController = go.GetComponent<EnemyShotController>();
                shotController.targetPosition = target.transform.position;//�^�[�Q�b�g���W��ݒ�

                //�e�ۂɑ��x��^����
                float shotForce = shotController.GetShotSpeed();
                shotController.ShotAddForce(this.transform.position + shotStartAdjustment, this.transform.forward * shotForce);

                //�J�E���g������
                nowShotCount -= shotInterval;

                //���ˌ��ʉ���炷
                //this.GetComponent<AudioSource>().PlayOneShot(clip);
            }
        }
    }
}
