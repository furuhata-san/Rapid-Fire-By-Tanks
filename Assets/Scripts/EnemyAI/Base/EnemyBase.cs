using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    [Header("�G�̗͍̑ő�l")]
    [SerializeField]
    private int lifeMax = 1;
    private int lifeNow;
    public int GetLifeNow() { return lifeNow; }
    public int GetLifeMax() { return lifeMax; }
    public void EnemyGetDamage(int damage) { lifeNow -= damage; }
    public bool JudgeEnemyDie() { return lifeNow <= 0; }

    [Header("�������A���������_��")]
    public bool randomRotateRespawn;

    [Header("���S���ɂȂ炷���ʉ��i������@�B���j")]
    public AudioSource dieAudioSource;

    [Header("���Z����X�R�A")]
    public int score = 100;
    public ScoreAndUIMgr ScoreMgr;
    public bool firstDied = true;//true�̂Ƃ���x�����X�R�A�����Z����

    void Awake()
    {
        //���C�t���ő�l��
        lifeNow = lifeMax;

        //���������_��
        if (randomRotateRespawn)
        {
            float step = Random.Range(-360, 360);
            transform.Rotate(Vector3.up, step);
        }

        //�X�R�A�}�l�[�W���[����
        ScoreMgr = GameObject.Find("GameManagement").GetComponent<ScoreAndUIMgr>();
    }

    //�e�ۂ��q�b�g�����Ƃ��̃_���[�W����
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "EnemyAttack") return;

        //�����_���[�W���A�^�b�`����Ă�����
        HaveDamage hc;
        if (hc = other.transform.GetComponent<HaveDamage>())
        {
            //���C�t�����炷
            lifeNow -= hc.GetDamage();//�X�N���v�g���̃_���[�W

            if (lifeNow <= 0)//�[���ȉ��ɂȂ�Ȃ��悤�ɕ␳
            {
                lifeNow = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "EnemyAttack") return;

        //�����_���[�W���A�^�b�`����Ă�����
        HaveDamage hc;
        if (hc = other.transform.GetComponent<HaveDamage>())
        {
            //���C�t�����炷
            lifeNow -= hc.GetDamage();//�X�N���v�g���̃_���[�W

            if (lifeNow <= 0)//�[���ȉ��ɂȂ�Ȃ��悤�ɕ␳
            {
                lifeNow = 0;
            }
        }
    }
}
