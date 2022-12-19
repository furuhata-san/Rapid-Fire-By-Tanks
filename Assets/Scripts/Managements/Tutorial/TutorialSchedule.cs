using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSchedule : MonoBehaviour
{
    [Header("�e�L�X�g�Q��"), SerializeField]
    private Text textObject;
    [Header("�{�b�N�X�̃R���g���[���["), SerializeField]
    private TextboxControl textboxControl;
    [Header("�E�N���b�N�}�E�X�摜"), SerializeField]
    private GameObject mouseRight;

    [System.Serializable]
    public struct Schedule
    {
        public string writeText;
        public TutorialChecker checker;
        public bool msRightClick;
    }
    [Header("�\���������e�L�X�g�ƕ\������(����O�b����v��)(������t����ꍇ�͏������������X�N���v�g��}��)")]
    public Schedule[] schedules = new Schedule[1];
    [SerializeField]
    public int scheduleNum;

    // Start is called before the first frame update
    void Start()
    {
        scheduleNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (scheduleNum < schedules.Length)
        {
            textObject.text = schedules[scheduleNum].writeText;

            mouseRight.SetActive(schedules[scheduleNum].msRightClick);

            //�����L����
            if (schedules[scheduleNum].checker)
            {
                schedules[scheduleNum].checker.enabled = true;
            }

            //�e�L�X�g�y�[�W����
            TextPage();

        }
    }

    public void TextPage()
    {
        //�E�N���b�N�Ńy�[�W
        bool pageNextFlag = Input.GetMouseButtonDown(1);
        
        //�������Q�Ƃ���Ă���ꍇ
        if (schedules[scheduleNum].checker)
        {
            //�N���b�N�t���O������������Ă���ꍇ
            if (!schedules[scheduleNum].msRightClick)
            {
                //������flag�Ńy�[�W����𔻒�
                pageNextFlag = schedules[scheduleNum].checker.flag;
            }
        }

        //�E�N���b�N�@���@�����𖞂����Ă���ꍇ
        if (pageNextFlag)
        {
            //�e�L�X�g�{�b�N�X���쓮
            textboxControl.SetFlag(true);
            //�e�L�X�g������
            textObject.text = "";

            //����X�N���v�g������ꍇ�A�y�����違�o�O�h�~�̂��ߖ�����
            if (schedules[scheduleNum].checker)
            {
                schedules[scheduleNum].checker.enabled = false;
            }
            //���̃X�P�W���[����
            ++scheduleNum;
        }
    }
}
