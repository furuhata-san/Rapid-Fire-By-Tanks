using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour
{
    [Header("�V���b�g�̏���")]
    [SerializeField]
    private float shotSpeed;
    public float GetShotSpeed()
    {
        return shotSpeed;
    }
    private float step; //�ړ����x�iTime.deltaTime�K�p��j
    [Header("�q�b�g�G�t�F�N�g�̃T�C�Y")]
    [SerializeField]
    private GameObject hitEffect;
    [SerializeField]
    private Vector3 normalEffectScale;//�ʏ�X�P�[��
    [SerializeField]
    private Vector3 hitPlayerEffectScale;//�v���C���q�b�g�X�P�[��
    [HideInInspector]
    public Vector3 targetPosition;//�^�[�Q�b�g�̈ʒu�A�V���b�g���΂��������w��

    public void ShotAddForce(Vector3 position, Vector3 Force)
    {
        this.transform.position = position;
        GetComponent<Rigidbody>().AddForce(Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        //�q�b�g�����R���C�_�[�̃^�O���V���b�g�������ꍇ�A�����Ȃ�
        if (other.transform.tag == "Enemy") return;
        if (other.transform.tag == "EnemyAttack") return;

        //�q�b�g�����̂ł����
        //�q�b�g�G�t�F�N�g����
        if (hitEffect)
        {
            Vector3 size;//�q�b�g�����I�u�W�F�N�g�ɂ���ăG�t�F�N�g�T�C�Y��ύX
            if (other.transform.tag == "Player")
            {
                size = this.hitPlayerEffectScale;
            }
            else
            {
                size = this.normalEffectScale;
            }

            GameObject go = Instantiate(hitEffect) as GameObject;
            go.GetComponent<EffectController>().Scale = size;
            go.transform.position = this.transform.position;
        }

        //�I�u�W�F�N�g��j��
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //�^�[�Q�b�g�̕����֒e��������
        Vector3 targetDir = targetPosition - transform.position;
        step = shotSpeed * Time.deltaTime;
        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);
        transform.rotation = Quaternion.LookRotation(moveDir);
    }

}
