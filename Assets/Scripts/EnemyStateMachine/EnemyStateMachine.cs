using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : EnemyBase
{
    //�X�e�[�g�}�V���֐�
    public enum State
    {
        Vigilance,  //�x�����[�h
        PlayerFind, //�����E�U�����[�h
        EnemyDie, //�폜���[�h

        //�ȉ��̏�ԂɂȂ����ꍇ�͕s��
        Now,        //���݂̏�Ԃ��ێ��i��Ԃł͂Ȃ��j
        Non,        //�����i�����j
    }
    [HideInInspector]
    public State nowState;
    [Header("���������ɃZ�b�g�����ԁi�����l�j")]
    public State firstState;
    [Header("�G�l�~�[���U�����󂯂��ꍇ�A�����ɓG������Ԃֈڍs����")]
    public bool discoveredWhenAttacked;
    private int saveLifeValue;

    [Header("�s�����A�^�b�`���ꂽ�X�N���v�g\n��Ԃ��ύX���ꂽ�ꍇ�iNow�ȊO�j�A�ȍ~�̏����͍s������Ԃ̕ω��͍s��Ȃ��B\n(��ԕω��̗D��x�͉��̃X�N���v�g���ł�����)")]
    public EnemyStateFunction[] esfVigilance = new EnemyStateFunction[1];
    public EnemyStateFunction[] esfPlayerFind = new EnemyStateFunction[1];
    public EnemyStateFunction[] esfEnemyDie = new EnemyStateFunction[1];

    // Start is called before the first frame update
    void Start()
    {
        nowState = firstState;
        saveLifeValue = GetLifeNow();
    }

    // Update is called once per frame
    void Update()
    {
        float tdt = Time.deltaTime;
        StateMachine(tdt);

        if (discoveredWhenAttacked)
        {
            if (!JudgeEnemyDie())
            {
                if (saveLifeValue != GetLifeNow())
                {
                    nowState = State.PlayerFind;
                }
            }
            saveLifeValue = GetLifeNow();
        }
    }

    void StateMachine(float tdt)
    {
        State stateChecker = State.Now;//�֐��̖߂�l��ۑ�
        State nextState = State.Now;//�߂�l��Now�ȊO�̏ꍇ�͂��̒l��ۑ����A�������s����܂ŕʂ̒l��ۑ����Ȃ��Ȃ�

        switch (nowState)
        {
            case State.Vigilance:
                for (int i = 0; i < esfVigilance.Length; ++i)
                {
                    stateChecker = esfVigilance[i].EnemyMove(tdt);
                    if (stateChecker != State.Now) { nextState = stateChecker; }
                }
                break;

            case State.PlayerFind:
                for (int i = 0; i < esfPlayerFind.Length; ++i)
                {
                    stateChecker = esfPlayerFind[i].EnemyMove(tdt);
                    if (stateChecker != State.Now) { nextState = stateChecker; }
                }
                break;

            case State.EnemyDie:
                DieStart();//�ŏ��̈�񂾂��������s��
                for (int i = 0; i < esfEnemyDie.Length; ++i)
                {
                    stateChecker = esfEnemyDie[i].EnemyMove(tdt);
                    if (stateChecker != State.Now) { nextState = stateChecker; }
                }
                break;

            default:
                Debug.LogError("�s���ȏ�Ԃł��F" + nowState);
                break;
        }

        if (JudgeEnemyDie())
        {
            nextState = State.EnemyDie;
        }


        //���݂̏�Ԃ��ێ����Ȃ��ꍇ�iNow�ȊO�̏ꍇ�j
        if (nextState != State.Now)
        {
            //��ԕύX
            nowState = nextState;
        }
    }

    void DieStart()
    {
        if (!firstDied) return;

        //�X�R�A���Z
        if(ScoreMgr) ScoreMgr.AddScore(score);
        
        //�����蔻��폜�i�ђʂ�����j
        Destroy(this.GetComponent<Collider>());
        
        //Ray���q�b�g���Ȃ��悤��(�G�C���J�[�\�����q�b�g������s��Ȃ�)
        this.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        
        //���S���ɂȂ炷�I�[�f�B�I������Ζ炷
        if (dieAudioSource) dieAudioSource.Play();

        //�t���O���I�t��
        firstDied = false;
    }
}
