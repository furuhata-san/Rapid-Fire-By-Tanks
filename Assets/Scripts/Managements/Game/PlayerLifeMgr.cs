using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeMgr : MonoBehaviour
{
    [Header("�v���C���̗͍̑ő�l")]
    [SerializeField]
    private int lifeMax = 1;
    private float lifeNow;
    private bool dieStartFlag;//���S�����

    [Header("�̗͂̉񕜑��x�i�P�b�Ԃ��Ɓj")]
    public float healSpeed;

    public float GetLifeNow() { return lifeNow; }
    public int GetLifeMax() { return lifeMax; }

    private void HealLife(float value) { 
        if (!dieStartFlag) return;
        lifeNow += value;
        if (lifeNow > lifeMax) lifeNow = lifeMax;
    }

    public void PlayerGetDamage(int damage) { lifeNow -= damage; }
    public bool JudgePlayerDie() { return lifeNow <= 0; }
    

    [Header("�v���C�����S���A�쐬����G�t�F�N�g")]
    public GameObject dieEffect;
    public Vector3 DieEffectScale;

    [Header("�v���C�����S���A������(�L����)����I�u�W�F�N�g")]
    public GameObject[] stopGameObjects = new GameObject[1];
    public GameObject[] playGameObjects = new GameObject[1];
    public MonoBehaviour[] stopScripts = new MonoBehaviour[1];

    void Awake()
    {
        //���C�t���ő�l��
        lifeNow = (float)lifeMax;
        dieStartFlag = true;
    }

    private void Update()
    {
        HealLife(healSpeed * Time.deltaTime);
        PlayerDie(JudgePlayerDie() && dieStartFlag);
    }




    private void PlayerDie(bool flag)
    {
        if (!flag) return;
        dieStartFlag = false;
        //�����G�t�F�N�g�����g�̍��W�ɍ쐬
        GameObject go = Instantiate(dieEffect);
        go.transform.position = this.transform.position;
        go.GetComponent<EffectController>().Scale = DieEffectScale;//�傫���ύX

        //�I�u�W�F�N�g��L�����i�������j
        for (int i = 0; i < stopGameObjects.Length; ++i)
        {
            if(stopGameObjects[i] != this.gameObject)//�o�O�h�~�i�v���C���͍Ō�ɖ������j
            {
                stopGameObjects[i].SetActive(false);
            }
        }
        for (int i = 0; i < playGameObjects.Length; ++i)
        {
            playGameObjects[i].SetActive(true);
        }
        for(int i = 0; i < stopScripts.Length; ++i) 
        {
            stopScripts[i].enabled = false;
        }
    }

    //�e�ۂ��q�b�g�����Ƃ��̃_���[�W����
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag != "EnemyAttack") return;

        //�����_���[�W���A�^�b�`����Ă�����
        HaveDamage hc;
        if (hc = other.transform.GetComponent<HaveDamage>())
        {
            //���C�t�����炷
            lifeNow -= hc.GetDamage();//�X�N���v�g���̃_���[�W
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "EnemyAttack") return;

        //�����_���[�W���A�^�b�`����Ă�����
        HaveDamage hc;
        if (hc = other.transform.GetComponent<HaveDamage>())
        {
            //���C�t�����炷
            lifeNow -= hc.GetDamage();//�X�N���v�g���̃_���[�W
        }
    }
}
