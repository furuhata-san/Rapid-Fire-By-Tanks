using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCreate : MonoBehaviour
{
    [Header("�{�X�������e�L�X�g")]
    public GameObject createText;

    private ScoreAndUIMgr sau;

    [System.Serializable]
    public struct Boss
    {
        public GameObject Prefab;
        public Vector3 pos;
        public Quaternion ang;
        public int createScore;
        public bool createFlag;
        public BuildingDestroyController bdc;
    }
    [Header("�{�X�I�u�W�F�N�g�X�R�A�A�Ăяo�����̃t���O(true�ŃI��)��ݒ�i�{�X�̓t�B�[���h�ɂP�̂̂ݐ����j")]
    public Boss[] boss = new Boss[1];
    private int createdNum = 0;
    private GameObject bossLive;

    // Start is called before the first frame update
    void Start()
    {
        sau = this.gameObject.GetComponent<ScoreAndUIMgr>();
        createdNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //�{�X�������ł����Ԃł����
        if (createdNum < boss.Length)
        {
            if (boss[createdNum].createFlag)
            {
                //�X�R�A�����������𖞂����Ă�����
                if (sau.GetNowScore() >= boss[createdNum].createScore)
                {
                    //�{�X�����݂��Ȃ��ꍇ
                    if (!bossLive)
                    {

                        //�{�X����
                        GameObject go = Instantiate(boss[createdNum].Prefab,
                                                    boss[createdNum].pos,
                                                    boss[createdNum].ang);
                        //�{�X�ۑ�
                        bossLive = go;
                        
                        //�󂷂ׂ��r��������ꍇ
                        if (boss[createdNum].bdc)
                            boss[createdNum].bdc.enabled = true;

                        //�e�L�X�g����
                        createText.SetActive(true);

                        //�����ł��Ȃ��悤�Ƀt���O���I�t��(�ꉞ)
                        boss[createdNum].createFlag = false;
                        //�i���o�[��ύX
                        ++createdNum;
                    }                }
            }

        }
    }
}
