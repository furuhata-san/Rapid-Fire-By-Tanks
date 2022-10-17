using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMeteorCreate : EnemyStateFunction
{
    [Header("覐΃v���t�@�u")]
    public GameObject meteorObject;
    public Vector2Int createValues;

    [Header("覐ΐ������A�炷���ʉ�")]
    public AudioSource createAudio;

    [Header("�v���C���[��T���i�v���C�����j")]
    public string playerObjectName;
    private GameObject player;//�v���C���[�����������A�i�[����

    //���L��̎��Ԃ��Ⴄ�ꍇ�A�t���O��L��������
    private float afterTime;//���݂̎���
    private float beforeTime;//�O��̎���
    private bool meteorCreateFlag;//true�Ȃ�覐΂𐶐�����

    // Start is called before the first frame update
    void Start()
    {
        meteorCreateFlag = true;
        afterTime = 0;
        beforeTime = 0;

        player = GameObject.Find(playerObjectName);
    }

    // Update is called once per frame
    void Update()
    {
        /*
          Enable�̏ꍇ�̂�::�J�E���g���O��ƕς���Ă��Ȃ��ꍇ�A
          state���Ăяo����Ă��Ȃ����߁A�ēx�L����������B
        */
        if (afterTime == beforeTime)
        {
            meteorCreateFlag = true;
        }
        else
        {
            afterTime = beforeTime;
        }
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        afterTime += Time.deltaTime;

        if (meteorCreateFlag)
        {
            CreateMeteorAsPlayer();
            int createNum = Random.Range(createValues.x, createValues.y);
            for(int i = 0; i < createNum; ++i)
            {
                CreateMeteorRandom();
            }
            meteorCreateFlag = false;
            createAudio.Play();
        }

        return EnemyStateMachine.State.Now;
    }

    private void CreateMeteorAsPlayer()
    {
        //�v���C���̈ʒu��覐ΐ���
        Vector3 pPos = player.transform.position;
        MeteorGenerator(new Vector3(pPos.x, 0, pPos.z));
    }

    private void CreateMeteorRandom()
    {
        //覐΂𐶐����邽�߂̍��W���}�X�ڂƂ��Đ錾����
        const int mapSlice = 10;
        const float cellSize = 10;

        float[] posX = new float[mapSlice];
        float[] posZ = new float[mapSlice];
        //�X���C�X���s���A���W�v�Z
        for (int i = 0; i < mapSlice; ++i)
        {
            posX[i] = ((-(mapSlice / 2) + i) * cellSize) + (cellSize / 2);
            posZ[i] = ((-(mapSlice / 2) + i) * cellSize) + (cellSize / 2);
        }

        //�}�X�ڂ̒l�������_���Ŏ擾
        int randomX = Random.Range(0, mapSlice);
        int randomZ = Random.Range(0, mapSlice);

        //覐ΐ���
        MeteorGenerator(new Vector3(posX[randomX], 0, posZ[randomZ]));
    }

    private void MeteorGenerator(Vector3 pos)
    {
        GameObject go = Instantiate(meteorObject);
        go.transform.position = pos;
    }
}
