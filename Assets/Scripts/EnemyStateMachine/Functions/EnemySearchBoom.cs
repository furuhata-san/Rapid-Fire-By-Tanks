using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySearchBoom : EnemyStateFunction
{
    private GameObject player;//�v���C���[�Ɍ������Đi��
    private NavMeshAgent navMeshAgent;//�i�r���b�V��
    private NavMeshHit navMeshHit;
    [Header("�v���C���������A�ړ����x���㏑������")]
    public float speedUp;
    [Header("�v���C���������A�A�j���[�V�����̑��x�X�V")]
    public Animator bootingAnimator;
    public float animPlaySpeed;

    [Header("�v���C���[���w�肵�������܂Őڋ߂����ꍇ�A����")]
    public float boomDistance;
    public GameObject boomObject;
    public Vector3 boomScale;
    private bool boomStart;

    [Header("�w�肵���J�E���g�𒴂����甚������")]
    public float boomTime;
    private float nowCount;

    [Header("�����J�n���̃T�E���h�i���ΐ��Ȃǁj")]
    public AudioSource fuseAudioSource;

    private void Start()
    {
        player = GameObject.Find("PlayerTank");
        navMeshAgent = GetComponent<NavMeshAgent>();
        nowCount = 0;
        boomStart = false;
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //�㏑��
        navMeshAgent.speed = speedUp;
        bootingAnimator.speed = animPlaySpeed;

        SearchPlayer();
        Boom(tdt);

        //�����ƕύX���Ȃ�
        return EnemyStateMachine.State.Now;
    }

    public void Boom(float tdt)//�����_���ړ�
    {
        //�i�r���b�V�����Ȃ��ꍇ�͏������s��Ȃ�
        //if (navMeshAgent == null) return;�i�i�r���b�V�����Ȃ��Ƃ������������Ȃ����߁A�G���[�𔭐�������j
        //�v���C���[�ɐڋ߂���[�����𔭐��[����莞�Ԍ�u�v���C���[�ɂ̂݃_���[�W�̂��锚���v�ő���������

        //�v���C���[�ɐڋ߂�����J�E���g�J�n�i���ΐ��ɉ΂�����j
        Vector3 Dir = this.transform.position - player.transform.position;

        //�t���O�ɂ���ď�����ύX
        if (boomStart)
        {
            //�t���O���I���Ȃ�J�E���g����
            nowCount += tdt;
        }
        else if (Dir.magnitude <= boomDistance)
        {
            //���ʉ���炵�A�����J�n
            fuseAudioSource.Play();
            boomStart = true;
        }

        //�������鎞�Ԃ��J�E���g�����߂����ꍇ
        if (boomTime <= nowCount)
        {
            //�����G�t�F�N�g�𐶐����A�폜�i�X�R�A�A�b�v�͂Ȃ��j
            //�����G�t�F�N�g�𐶐�
            GameObject go = Instantiate(boomObject) as GameObject;
            go.transform.position = this.transform.position;//�ʒu��G�̈ʒu�ֈړ�
            go.GetComponent<EffectController>().Scale = boomScale;//�傫���ύX

            //�j��
            Destroy(gameObject);
        }


        return;
    }

    private void SearchPlayer()//�ڕW�n�_��Bake����Ă���n�_���烉���_���őI��
    {
        Vector3 playerPos = player.transform.position;
        NavMesh.SamplePosition(playerPos, out navMeshHit, 5, 1);
        navMeshAgent.destination = navMeshHit.position;
    }
}
