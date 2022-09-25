using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeAndUIMgr : MonoBehaviour
{
    [Header("�Ή����郉�C�t�̃C���[�W��}��")]
    public Image LifeBase;
    public Image LifeRed;
    public Image LifeGreen;

    [Header("�ԃQ�[�W����������X�s�[�h�{��")]
    public float redGaugeMoveSpeed;

    [Header("�v���C�����Q�Ƃ���Ă��Ȃ��ꍇ�̓G�l�~�[�������I�ɐݒ�")]
    public PlayerLifeMgr playerLifeMgr;
    //�Q�Ƃ���G�l�~�[
    [HideInInspector]
    public EnemyBase ebase;
    //�ȉ��m�F�p�ɕۊǂ���Q�ƌ�
    [HideInInspector]
    public EnemyBase saveEBase;

    private float saveLifeNow;

    private void Start()
    {
        //���݂̃��C�t��ۑ�
        if (playerLifeMgr)
        {
            saveLifeNow = playerLifeMgr.GetLifeNow();
        }
        else if(ebase)
        {
            saveLifeNow = ebase.GetLifeNow();
        }
        
    }

    private void Update()
    {
        if (playerLifeMgr)
        {
            PlayerLifeUI();
        }
        else if (ebase)
        {
            EnemyLifeUI();
        }
    }

    private void PlayerLifeUI()
    {
        //���݂̗̑͂���Q�[�W�̌����ʂ��v�Z����
        float lifeMoveSizeW = 1.0f / playerLifeMgr.GetLifeMax() * playerLifeMgr.GetLifeNow();

        //�΃Q�[�W�̃T�C�Y��ύX
        LifeGreen.transform.localScale = new Vector3(lifeMoveSizeW, 1, 1);

        //�����ԃQ�[�W���΃Q�[�W���傫�������ꍇ
        if (LifeRed.transform.localScale.x >= LifeGreen.transform.localScale.x)
        {
            if (playerLifeMgr.GetLifeNow() <= 0)
            {
                //�ԃQ�[�W�̃T�C�Y������
                //�̗͂��O�ȉ��̏ꍇ�͒ʏ푬�x
                LifeRed.transform.localScale -= new Vector3((float)(saveLifeNow - playerLifeMgr.GetLifeNow()) / (float)playerLifeMgr.GetLifeMax() * Time.deltaTime, 0, 0);
            }
            else
            {
                //�ԃQ�[�W�̃T�C�Y������
                //�_���[�W�ʂ�����Ă��Ă��A�ԃQ�[�W�̌����鎞�Ԃ͓������Ȃ�
                LifeRed.transform.localScale -= new Vector3((float)(saveLifeNow - playerLifeMgr.GetLifeNow()) / (float)playerLifeMgr.GetLifeMax() * Time.deltaTime * redGaugeMoveSpeed, 0, 0);
            }
        }
        else
        {
            //�ԃQ�[�W�Ɨ΃Q�[�W�̃T�C�Y�𓙂�������
            LifeRed.transform.localScale = LifeGreen.transform.localScale;
            //���݂̃��C�t��ۑ�
            saveLifeNow = playerLifeMgr.GetLifeNow();
        }

        

    }

    private void EnemyLifeUI()
    {
        //���݂̗̑͂���Q�[�W�̌����ʂ��v�Z����
        float lifeMoveSizeW = 1.0f / ebase.GetLifeMax() * ebase.GetLifeNow(); ;

        //�΃Q�[�W�̃T�C�Y��ύX
        LifeGreen.transform.localScale = new Vector3(lifeMoveSizeW, 1, 1);

        //�ȉ��A�ԃQ�[�W��������茸�������鏈��/////////////////////////////////////////////////

        //�O��̏�����EnemyBase���قȂ��Ă�����Q�[�W�㏑��
        if (saveEBase != ebase)
        {
            //�ԃQ�[�W�̃T�C�Y��΃Q�[�W�Ɠ����ɂ���
            LifeRed.transform.localScale = LifeGreen.transform.localScale;
            //�ۑ����Ă���Q�ƌ���ύX
            saveEBase = ebase;
            //���݂̃��C�t��ۑ�
            saveLifeNow = ebase.GetLifeNow();
        }

        //�����ԃQ�[�W���΃Q�[�W���傫�������ꍇ
        if (LifeRed.transform.localScale.x >= LifeGreen.transform.localScale.x)
        {
            if (ebase.GetLifeNow() <= 0)
            {
                //�ԃQ�[�W�̃T�C�Y������
                //�̗͂��O�ȉ��̏ꍇ�͒ʏ푬�x
                LifeRed.transform.localScale -= new Vector3((float)(saveLifeNow - ebase.GetLifeNow()) / (float)ebase.GetLifeMax() * Time.deltaTime, 0, 0);
            }
            else
            {
                //�ԃQ�[�W�̃T�C�Y������
                //�_���[�W�ʂ�����Ă��Ă��A�ԃQ�[�W�̌����鎞�Ԃ͓������Ȃ�
                LifeRed.transform.localScale -= new Vector3((float)(saveLifeNow - ebase.GetLifeNow()) / (float)ebase.GetLifeMax() * Time.deltaTime * redGaugeMoveSpeed, 0, 0);
            }
        }
        else
        {
            //�ԃQ�[�W�Ɨ΃Q�[�W�̃T�C�Y�𓙂�������
            LifeRed.transform.localScale = LifeGreen.transform.localScale;
            //���݂̃��C�t��ۑ�
            saveLifeNow = ebase.GetLifeNow(); ;
        }

        
    }
}

