using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSchedule : MonoBehaviour
{
    [System.Serializable]
    public struct Schedule
    {
        public GameObject gameObject;
        public float time;
    }
    [Header("�x��:���̃Q�[���I�u�W�F�N�g���Q�ƃI�u�W�F�N�g�ɂ��Ȃ�����")]
    public Schedule[] schedule = new Schedule[1];
    
    private float Timer;
    private int scheduleNum;

    // Start is called before the first frame update
    void Start()
    {
        //���̏�����
        Timer = 0;
        scheduleNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԃ̒ǉ�
        Timer += Time.deltaTime;

        //�X�P�W���[���̎��Ԃ��߂��Ă�����
        if(schedule[scheduleNum].time <= Timer)
        {
            //�Q�[���I�u�W�F�N�g��L����
            ObjectActive(schedule[scheduleNum].gameObject, true);
            //�^�C�}�[���Z�b�g
            Timer = 0;
            //�X�P�W���[����ύX
            ++scheduleNum;
        }

        //�X�P�W���[��������ȏ�Ȃ��ꍇ�Q�[���I�u�W�F�N�g��j��
        if (scheduleNum >= schedule.Length) Destroy(gameObject);

    }

    void ObjectActive(GameObject go, bool flag)
    {
        go.SetActive(flag);
    }

}
