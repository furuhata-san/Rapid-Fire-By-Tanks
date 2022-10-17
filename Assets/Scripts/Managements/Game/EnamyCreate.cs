using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamyCreate : MonoBehaviour
{
    [Header("���Y�������G�l�~�[��Prafab���Z�b�g")]
    public GameObject[] EnemyPrefab = new GameObject[1];

    public GameObject[] GoEnemy = new GameObject[1];//�G���ő吔�ȏ㐶���ł��Ȃ�����

    [Header("�G�𐶐�����ۂ̃G�t�F�N�g")]
    public GameObject createEffect;


    [Header("�v���C���[�̃I�u�W�F�N�g��}���i���W�ʒu���m�肽�����߁j")]
    public GameObject player;

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
            //�G���P�̂�����������
            bool createFlag = false;
            int EnemyNum = Random.Range(0, EnemyPrefab.Length);
            for (int i = 0; i < GoEnemy.Length && !createFlag; ++i)
            {
                //�z��̗v�f���󂢂Ă����ꍇ�A�G�𐶐�����B
                if (!GoEnemy[i])
                {
                    GameObject go = Instantiate(EnemyPrefab[EnemyNum], SetPosSlicePos(i), transform.rotation);
                    GoEnemy[i] = go;//�G��z��ɕۑ�
                    createFlag = true;
                }
            }
        }
    }

    public Vector3 SetPosSlicePos(int for_I)
    {
        //�G�𐶐����邽�߂̍��W���}�X�ڂƂ��Đ錾����
        float[] posX = new float[mapSlice];
        float[] posZ = new float[mapSlice];
        //�X���C�X���s���A���W�v�Z
        for (int i = 0; i < mapSlice; ++i)
        {
            //�}�b�v���[(-4�`5) => 0�͒��S�̍���iZ�������ʕ����������Ă���ꍇ�j
            //�}�b�v���[���猻�݂̔ԍ�(i)�������Z���A�}�X�ڒ��S�i�P�}�X�̔����j��������
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

            //��������}�X�ڂ̗v�f�ԍ��������_���Ŏ擾
            randomX = Random.Range(0, mapSlice);
            randomZ = Random.Range(0, mapSlice);

            //�v���C���[�̌��݂̍��W���擾���A�T�C�Y���}�X�ڕ��g��
            //(�}�X�ڂ̒��S�ɂ����ꍇ�͐������Ȃ��A�[�ɂ����ꍇ�͐�������)
            float PlayerAreaSize = cellSize * 1.75f;
            float pPosMinX = player.transform.position.x - PlayerAreaSize;
            float pPosMaxX = player.transform.position.x + PlayerAreaSize;
            float pPosMinZ = player.transform.position.z - PlayerAreaSize;
            float pPosMaxZ = player.transform.position.z + PlayerAreaSize;

            //�ȉ��v���C���[�A�������͂��łɑ��݂��Ă���G�Əd�Ȃ��Ă��Ȃ����̔�����s���B
            //�t���O��true�ɂȂ����u�Ԕ�����I������

            //�v���C���[�̍��W���G�����\��n�̎��ӂ������ꍇ�͍ēx���[�v���s���iXZ�����g�p�����Q�c�̋�`�̓����蔻��j
            ///�i��d���[�v�폜�j
            if (pPosMinX <= posX[randomX] && posX[randomX] <= pPosMaxX)
            {//�v���C���[�t�߂̏ꍇ�i�w�j
                if (pPosMinZ <= posZ[randomZ] && posZ[randomZ] <= pPosMaxZ)//�v���C���[�t�߂̏ꍇ�i�y�j
                {
                    //�ēx���[�v
                    loopFlag = true;//(for���I��)
                }
            }



            //���̓G�ƍ��W�����Ԃ��Ă���ꍇ�A�ēx���[�v
            for(int i = 0; i < GoEnemy.Length && loopFlag == false; ++i)
            {
                if(i != for_I)//���g�̔ԍ��ƈقȂ�ꍇ
                {
                    if (GoEnemy[i])//�G����������Ă���ꍇ
                    {
                        if ((GoEnemy[i].transform.position.x - posX[0]) / cellSize == randomX)//X���W�ԍ��������ꍇ
                        {
                            if ((GoEnemy[i].transform.position.z - posZ[0]) / cellSize == randomZ)//Z���W�ԍ��������ꍇ
                            {
                                //�ēx���[�v
                                loopFlag = true;//for���I��
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
