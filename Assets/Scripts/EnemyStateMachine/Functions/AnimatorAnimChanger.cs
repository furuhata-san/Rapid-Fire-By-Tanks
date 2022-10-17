using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAnimChanger : EnemyStateFunction
{
    [Header("���S���A�ύX�������A�j���[�V�����̃g���K�[��")]
    public string animTriggerName;

    [Header("�A�j���[�^�[���Q�Ɓi�}������Ă��Ȃ��ꍇ�͎����������s���j")]
    private Animator animator;
    private bool firstFlag;

    public enum AnimPlayMode
    {
        Once,
        Enable,
        AllTime,
        Non,
    };
    [Header("�A�j���[�V�����X�V�̕��@")]
    public AnimPlayMode playMode;

    //[Enable�̂�]
    //���L��̎��Ԃ��Ⴄ�ꍇ�A�t���O��L��������
    private float afterTime;//���݂̎���
    private float beforeTime;//�O��̎���

    // Start is called before the first frame update
    void Start()
    {
        firstFlag = true;
        //�A�j���[�^�[���Q�Ƃ���Ă��Ȃ������ꍇ
        if (!animator)
        {
            //�A�j���[�^�[����������
            animator = this.GetComponent<Animator>();
        }
        afterTime = 0;
        beforeTime = 0;
    }

    private void Update()
    {
        /*
        Enable�̏ꍇ�̂�::�J�E���g���O��ƕς���Ă��Ȃ��ꍇ�A
        state���Ăяo����Ă��Ȃ����߁A�ēx�L����������B
        */    
        if (playMode == AnimPlayMode.Enable)
        {
            if (afterTime == beforeTime)
            {

                firstFlag = true;
            }
            else
            {
                afterTime = beforeTime;
            }
        }
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        afterTime += Time.deltaTime;

        //���[�h�ɂ���ď����ύX
        switch (playMode)
        {
            case AnimPlayMode.Once:
                if (!firstFlag) return EnemyStateMachine.State.Now;
                firstFlag = false;
                break;

            case AnimPlayMode.Enable:
                if (!firstFlag) return EnemyStateMachine.State.Now;
                firstFlag = false;
                break;

            case AnimPlayMode.Non:
                Debug.Log("�A�j���[�V������������Ԃł��B");
                return EnemyStateMachine.State.Now;

            default:
                break;
        }

        //�A�j���[�V�������X�V
        animator.SetTrigger(animTriggerName);

        return EnemyStateMachine.State.Now;
    }
}
