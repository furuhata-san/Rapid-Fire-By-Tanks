using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFallDie : EnemyStateFunction
{
    [Header("�������x")]
    public float fallSpeed;

    [Header("�����J�n���Ă���A���j����܂ł̎���")]
    public float destroyTime;
    private float destroyTimer;

    [Header("���S����]���x�Ƒ��x�{��")]
    public float dieRotateSpeed;
    public Vector3 dieRotatePow;

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
        EnemyDieFallAndRotateY(tdt);

        return EnemyStateMachine.State.Now;
    }


    public void EnemyDieFallAndRotateY(float tdt)
    {

        //�J�E���g�𑝂₷
        destroyTimer += tdt;

        //�i�r���b�V���G�[�W�F���g������
        NavMeshAgentOff();

        //��]������
        float rot = ((dieRotateSpeed) * tdt) / destroyTime;
        Vector3 rotSet = new Vector3(rot * dieRotatePow.x, rot * dieRotatePow.y, rot * dieRotatePow.z);
        transform.Rotate(rotSet);

        //���ֈړ�
        float Pos = fallSpeed * tdt;
        NMA.baseOffset -= Pos;


        if (destroyTimer >= destroyTime) //�w��b���o�ߌ�
        {
            //�����G�t�F�N�g�𐶐�
            GameObject go = Instantiate(destroyEffect) as GameObject;
            go.transform.position = this.transform.position;//�ʒu��G�̈ʒu�ֈړ�
            go.GetComponent<EffectController>().Scale = effectScale;//�傫���ύX

            //�j��
            Destroy(gameObject);
        }
    }

    public void NavMeshAgentOff()//�i�r���b�V��������
    {
        //�ړ��Ɖ�]���~[

        NMA.speed = 0;
        NMA.angularSpeed = 0;
    }
}
