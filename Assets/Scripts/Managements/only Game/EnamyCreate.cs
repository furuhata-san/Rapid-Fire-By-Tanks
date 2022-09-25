using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamyCreate : MonoBehaviour
{
    [Header("���Y�������G�l�~�[��Prafab���Z�b�g")]
    public GameObject[] EnemyPrefab = new GameObject[1];

    const int CreateEnemyMax = 10;
    public GameObject[] GoEnemy = new GameObject[CreateEnemyMax];//�G���ő吔�ȏ㐶���ł��Ȃ�����

    [Header("�G�𐶐�����ۂ̃G�t�F�N�g")]
    public GameObject createEffect;


    [Header("�v���C���[�̃I�u�W�F�N�g��}���i���W�ʒu���m�肽�����߁j")]
    public GameObject player;
    public float createPositionDistance;

    [Header("�쐬�����̍ő�l")]
    public float RandomMax = 100;

    [Header("�����Ŏ擾�������l�����̐��l�ȉ��Ȃ�G�𐶐�")]
    [SerializeField]
    private float RandomCreate = 1;

    [Header("�ȉ����W�v�Z")]
    private const int mapSlice = 10;
    public int cellSize;

    private void Start()
    {
        //���̂Ƃ��돈���Ȃ�
    }

    void Update()
    {
        EnemyGenerator();
    }

    void EnemyGenerator()
    {
        float randomNum = Random.Range(0, RandomMax);
        if (randomNum <= RandomCreate)
        {
            int EnemyNum = Random.Range(0, EnemyPrefab.Length);

            bool createFlag = false;
            for (int i = 0; i < CreateEnemyMax && !createFlag; ++i)
            {
                //�z��̗v�f���󂢂Ă����ꍇ�A�G�𐶐�����B
                if (!GoEnemy[i])
                {
                    GameObject go = Instantiate(EnemyPrefab[EnemyNum], SetPos10x10z(i), transform.rotation);
                    GoEnemy[i] = go;//�G��z��ɕۑ�
                    createFlag = true;
                }
            }
        }
    }

    public Vector3 SetPos10x10z(int for_I)
    {
        //�G�𐶐����邽�߂̍��W���}�X�ڂƂ��Đ錾����
        float[] posX = new float[mapSlice];
        float[] posZ = new float[mapSlice];
        //�X���C�X���s���A���W�v�Z
        for (int i = 0; i < mapSlice; ++i)
        {
            posX[i] = ((-(mapSlice / 2) + i) * cellSize) + (cellSize / 2);
            posZ[i] = ((-(mapSlice / 2) + i) * cellSize) + (cellSize / 2);
        }

        //�����Ŏ擾�����l���v���C���[�Əd�Ȃ�Ȃ��ʒu�ɂȂ�܂Ń��[�v
        bool loopFlag = true;
        int randomX = 0, randomZ = 0;
        while (loopFlag)
        {
            //�Ō��for���Ŕ�����s�����߈�x�������[�v�𖳌���
            loopFlag = false;

            //��������}�X�ڂ̒l�������_���Ŏ擾
            randomX = Random.Range(0, mapSlice);
            randomZ = Random.Range(0, mapSlice);
            //�v���C���[�̌��݂̍��W���擾
            float pPosMinX = player.transform.position.x - createPositionDistance;
            float pPosMaxX = player.transform.position.x + createPositionDistance;
            float pPosMinZ = player.transform.position.z - createPositionDistance;
            float pPosMaxZ = player.transform.position.z + createPositionDistance;

            //�v���C���[�̍��W���G�����\��n�̎��ӂ������ꍇ�͍ēx���[�v���s��
            for (int x = -1; x <= 1 && loopFlag == false; ++x) { 
                for (int z = -1; z <= 1; ++z){//��d���[�v
                    if (randomX + x >= 0 && randomX + x < mapSlice){//�I�[�o�[�����h�~
                        if (randomZ + z >= 0 && randomZ + z < mapSlice){//�I�[�o�[�����h�~
                            if(pPosMinX <= posX[randomX] && posX[randomX] <= pPosMaxX){//�v���C���[�t�߂̏ꍇ
                                if (pPosMinZ <= posZ[randomZ] && posZ[randomZ] <= pPosMaxZ)//�v���C���[�t�߂̏ꍇ
                                {
                                    //�ēx���[�v
                                    loopFlag = true;
                                }
                            }
                        }
                    }
                }
            }

            //���̓G�ƍ��W�����Ԃ��Ă���ꍇ�A�ēx���[�v
            for(int i = 0; i < CreateEnemyMax; ++i)
            {
                if(i != for_I)//���g�̔ԍ��ƈقȂ�ꍇ
                {
                    if (GoEnemy[i])
                    {
                        if (GoEnemy[i].transform.position.x / cellSize ==
                            randomX)//X���W�ԍ��������ꍇ
                        {
                            if (GoEnemy[i].transform.position.y / cellSize ==
                                randomZ)//Z���W�ԍ��������ꍇ
                            {
                                loopFlag = true;//�ēx���[�v
                            }
                        }
                    }
                }
            }

        }

        //�G�t�F�N�g����
        GameObject effect = Instantiate(createEffect);
        effect.transform.position = new Vector3(posX[randomX], 0, posZ[randomZ]);
        return new Vector3(posX[randomX], 0, posZ[randomZ]);
    }
}
