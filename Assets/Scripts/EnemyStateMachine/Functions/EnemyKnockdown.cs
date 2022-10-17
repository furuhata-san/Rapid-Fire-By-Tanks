using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyKnockdown : EnemyStateFunction
{
    [Header("�|��鑬�x")]
    public float rotateSpeed;
    public Vector3 dieRotatePow;

    [Header("�|��͂��߂Ă���A���j����܂ł̎���")]
    public float destroyTime;
    private float destroyTimer;    

    [Header("���S���G�t�F�N�g")]
    public GameObject destroyEffect;
    public Vector3 effectScale;
    private NavMeshAgent NMA;

    private void Start()
    {
        destroyTimer = 0;
        NMA = GetComponent<NavMeshAgent>();
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //�������Ĉړ��iNavMesh�j
        EnemyDieRotate(tdt);

        return EnemyStateMachine.State.Now;
    }

    public void EnemyDieRotate(float tdt)
    {
        //�J�E���g�𑝂₷
        destroyTimer += tdt;

        //�i�r���b�V���G�[�W�F���g������
        NavMeshAgentDelete();

        //��]������
        float rot = ((rotateSpeed) * tdt) / destroyTime;
        Vector3 rotSet = new Vector3(rot * dieRotatePow.x, rot * dieRotatePow.y, rot * dieRotatePow.z);
        transform.Rotate(rotSet);

        if (destroyTimer >= destroyTime) //�w��b���o�ߌ�
        {
            //�����G�t�F�N�g�𐶐�
            GameObject go = Instantiate(destroyEffect) as GameObject;
            go.transform.position = this.transform.position;//�ʒu��G�̈ʒu�ֈړ�
            go.GetComponent<EffectController>().Scale = effectScale;//�傫���ύX

            //�������������͔j��
            //state = State.Non;
            Destroy(gameObject);//������
        }
    }

    public void NavMeshAgentDelete()//�i�r���b�V���R���|�[�l���g�폜
    {
        if (NMA != null)
        {
            Destroy(NMA);
        }
    }
}
