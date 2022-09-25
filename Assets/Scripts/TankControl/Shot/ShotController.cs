using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [Header("�V���b�g�̏���")]
    public float shotSpeed;
    private float step;
    [Header("�q�b�g�G�t�F�N�g�̃T�C�Y")]
    public GameObject hitEffect;
    public Vector3 EffectScale;
    [HideInInspector]
    public AimController acz;
    private Vector3 targetPosition;

    [HideInInspector]
    public LifeAndUIMgr lifeAndUI;

    public void ShotAddForce(Vector3 position, Vector3 Force)
    {
        this.transform.position = position;
        GetComponent<Rigidbody>().AddForce(Force);
    }

    private void OnCollisionEnter(Collision other)
    {
        //�q�b�g�����R���C�_�[�̃^�O���v���C���[���V���b�g�������ꍇ�A�����Ȃ�
        if (other.transform.tag == "Player") return;
        if (other.transform.tag == "Shot") return;

        //�q�b�g�����̂ł����
        //�q�b�g�G�t�F�N�g����
        if (hitEffect)
        {
            GameObject go = Instantiate(hitEffect) as GameObject;
            go.GetComponent<EffectController>().Scale = this.EffectScale;
            go.transform.position = this.transform.position;
        }
        if (other.transform.tag == "Enemy")
        {
            //�̗̓Q�[�W�̑ΏۂƂȂ�G��ύX
            lifeAndUI.ebase = other.gameObject.GetComponent<EnemyBase>();
        }
        //�I�u�W�F�N�g��j��
        Destroy(gameObject);
    }

    private void Start()
    {
        targetPosition = acz.blHit.point;
        step = shotSpeed * Time.deltaTime;
        Vector3 targetDir = targetPosition - transform.position;
        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);
        transform.rotation = Quaternion.LookRotation(moveDir);
    }
}
