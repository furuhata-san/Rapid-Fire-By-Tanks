using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAndUIMgr : MonoBehaviour
{
    [Header("�^�C�}�[�̃C���[�W�ƃe�L�X�g")]
    public Image timer;
    public Text text;
    [Header("�c��30�b���ɕ\������e�L�X�g")]
    public GameObject thirtySec;
    private bool thirtySecFlag = false;
    [Header("��������")]
    [SerializeField]
    private float TimeLimit = 10.0f;
    public float nowTime;
    public GameObject finishText;
    [Header("�I�[�f�B�I�\�[�X�̑}��")]
    public AudioSource gameBGM;
    [Range(0.0f,3.0f)]
    public float fastPitch = 1.2f;
    [Range(0.0f, 3.0f)]
    public float slowPitch = 1.0f;
    [Header("�V�[���ڍs�̃I�u�W�F�N�g")]
    public SceneAndFadeOutMgr sceneMgr;
    public AudioClip gong;
    private bool gongFlag = true;
    [Header("���Ԑ؂�̍ہA����������I�u�W�F�N�g")]
    public GameObject TankCanon;
    // Start is called before the first frame update
    void Start()
    {
        nowTime = TimeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[�W�ϓ�
        timer.fillAmount = (nowTime / TimeLimit);

        //�e�L�X�g�ύX
        nowTime -= Time.deltaTime;
        if (nowTime <= 0)
        {
            nowTime = 0;  //���Ԃ����̒l�̏ꍇ�O�ɏ㏑��
            if (gongFlag)
            {
                //�L���m��������
                TankCanon.SetActive(false);
                //�t�B�j�b�V���e�L�X�g�L����
                finishText.SetActive(true);
                gameBGM.Stop();
                this.GetComponent<AudioSource>().PlayOneShot(gong);
                sceneMgr.Go_Result();
                gongFlag = false;
            }
        }

        //�c��30�b�e�L�X�g
        if (thirtySecFlag)
        {
            if (nowTime <= 30.0f)//�O�\�b�ȉ�
            {
                thirtySec.SetActive(true);
                gameBGM.pitch = fastPitch;
                thirtySecFlag = false;
            }
        }
        else if(nowTime > 30.0f)//�O�\�b�ȏ�Ȃ�ēx�L����
        {
            gameBGM.pitch = slowPitch;
            thirtySecFlag = true;
        }

        //�f�o�b�O�p�R�[�h
        if (Input.GetKey(KeyCode.F5))
        {
            nowTime += Time.deltaTime * 50;
        }
        else if (Input.GetKey(KeyCode.F6))
        {
            nowTime -= Time.deltaTime * 50;
        }

        //�������Ԃ��傫���ꍇ
        if(nowTime > TimeLimit)
        {
            //�ő�l�ȏ�ɂȂ�Ȃ��悤�␳
            nowTime = TimeLimit;
        }

        text.text = "" + (int)nowTime; //���Ԃ�10���߂̏ꍇ�ɕ\��
    }
}
