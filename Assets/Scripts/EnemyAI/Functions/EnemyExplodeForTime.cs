using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodeForTime : EnemyStateFunction
{
    [Header("���S���Ă���폜�܂ł̎���")]
    public float destroyTime;//���S����
    private float destroyCount;//���S�������J�E���g

    [Header("���S���G�t�F�N�g")]
    public GameObject DestroyEffect;
    public Vector3 DieEffectScale;

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //�J�E���g�𑝂₷
        destroyCount += tdt;

        //�����蔻����Ȃ���
        Rigidbody rb;
        if (rb = GetComponent<Rigidbody>())
        {
            rb.isKinematic = true;
        }

        if (destroyCount >= destroyTime) //�w��b���o�ߌ�
        {
            //�����G�t�F�N�g�𐶐�
            GameObject go = Instantiate(DestroyEffect) as GameObject;
            go.transform.position = this.transform.position;//�ʒu��G�̈ʒu�ֈړ�
            go.GetComponent<EffectController>().Scale = DieEffectScale;//�傫���ύX

            //�j��
            Destroy(gameObject);
        }

        return EnemyStateMachine.State.Now;
    }
}
