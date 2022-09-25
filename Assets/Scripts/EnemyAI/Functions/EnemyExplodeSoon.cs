using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodeSoon : EnemyStateFunction
{
    [Header("���S���̃G�t�F�N�g�̐ݒ�")]
    public GameObject DestroyEffect;
    public Vector3 DieEffectScale;

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //�������j
        //�����G�t�F�N�g�𐶐�
        GameObject go = Instantiate(DestroyEffect) as GameObject;
        go.transform.position = this.transform.position;//�ʒu��G�̈ʒu�ֈړ�
        go.GetComponent<EffectController>().Scale = DieEffectScale;//�傫���ύX

        //�j��
        Destroy(gameObject);//������

        return EnemyStateMachine.State.Now;
    }
}

