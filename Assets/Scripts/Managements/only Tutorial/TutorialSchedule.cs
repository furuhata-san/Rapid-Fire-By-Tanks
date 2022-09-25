using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSchedule : MonoBehaviour
{
    public GameObject textGameObject;
    public TextboxControl textboxControl;
    private Text textData;

    [System.Serializable]
    public struct Schedule
    {
        public string writeText;
        public float writeTime;
        public TutorialChecker checker;
    }
    [Header("�\���������e�L�X�g�ƕ\������(����O�b����v��)(������t����ꍇ�͏������������X�N���v�g��}��)")]
    public Schedule[] schedules = new Schedule[1];
    [SerializeField]
    public int scheduleNum;
    public float textTimer;

    // Start is called before the first frame update
    void Start()
    {
        scheduleNum = 0;
        textTimer = 0;
        textData = textGameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scheduleNum < schedules.Length)
        {
            textData.text = schedules[scheduleNum].writeText;

            if (schedules[scheduleNum].checker)
            {
                schedules[scheduleNum].checker.enabled = true;
                //���肪true�ɂȂ����玞�Ԃ����Z
                if (schedules[scheduleNum].checker.GetFlag())
                {
                    timerUpdate();
                }
            }
            else
            {
                //���Ԃ����Z
                timerUpdate();
            }

            //������
            if (Input.GetMouseButtonDown(1))
            {
                if (schedules[scheduleNum].checker)
                    schedules[scheduleNum].checker.flag = true;
                textTimer = 999.0f;
            }
        }
    }

    public void timerUpdate()
    {
        textTimer += Time.deltaTime;

        //�\�����Ԃ𒴂��Ă�����
        if (schedules[scheduleNum].writeTime <= textTimer)
        {
            //�e�L�X�g�{�b�N�X���쓮
            textboxControl.SetFlag(true);
            //�e�L�X�g������
            textData.text = "";
            //���Ԃ�������
            textTimer = 0;
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
