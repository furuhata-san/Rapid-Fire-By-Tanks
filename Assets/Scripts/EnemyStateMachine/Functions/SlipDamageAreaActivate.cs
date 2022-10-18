using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipDamageAreaActivate : EnemyStateFunction
{
    [Header("�^���I�ɃX���b�v�_���[�W�ɂ������ꍇ�A�R���C�_�[�i�����蔻��j���Q�Ƃ���")]
    public Collider hitArea;
    [SerializeField]
    private bool startSetActive = true;

    [Header("�L�����i�������j��Ԃɐ؂�ւ��鎞��")]
    public float intervalGoToFalse;
    public float intervalGoToTrue;
    private float nowCount;

    // Start is called before the first frame update
    void Start()
    {
        hitArea.enabled = startSetActive;
    }

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        nowCount += Time.deltaTime;

        float intervalCopy = 0;
        if (hitArea.enabled)//�R���C�_�[�L����
        {
            intervalCopy = intervalGoToFalse;
        }
        else//�R���C�_�[������
        {
            intervalCopy = intervalGoToTrue;
        }

        if (nowCount >= intervalCopy)
        {
            //�t���O���]
            hitArea.enabled = !hitArea.enabled;
            nowCount = 0;
        }

        return EnemyStateMachine.State.Now;
    }
}
