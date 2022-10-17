using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [Header("�V���b�g�̏���")]
    [SerializeField]
    private float shotSpeed;
    public float GetShotSpeed() { return shotSpeed; }
    private float step;


    [Header("�q�b�g�G�t�F�N�g�̃T�C�Y")]
    [SerializeField]
    private GameObject hitEffect;
    [SerializeField]
    private Vector3 EffectScale;
    

    //�G�C���ʒu�̎Q��
    private AimController aim;
    public void SetAimController(AimController aim_) { aim = aim_; }
    private Vector3 targetPosition;


    [Header("���ˌ�A�j��܂ł̎���")]
    [SerializeField]
    private float limitTime = 1.0f;
    private float timer = 0;

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

        //�̗̓Q�[�W�̑ΏۂƂȂ�G��ύX
        lifeAndUI.ebase = other.gameObject.GetComponent<EnemyBase>();
    }

    private void Start()
    {
        targetPosition = aim.GetBulletHit().point;
        step = shotSpeed * Time.deltaTime;
        Vector3 targetDir = targetPosition - transform.position;
        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);
        transform.rotation = Quaternion.LookRotation(moveDir);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(limitTime <= timer)
        {
            Destroy(gameObject);
        }
    }

}
