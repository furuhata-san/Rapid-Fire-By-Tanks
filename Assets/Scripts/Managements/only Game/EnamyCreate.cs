using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamyCreate : MonoBehaviour
{
    [Header("生産したいエネミーのPrafabをセット")]
    public GameObject[] EnemyPrefab = new GameObject[1];

    const int CreateEnemyMax = 10;
    public GameObject[] GoEnemy = new GameObject[CreateEnemyMax];//敵を最大数以上生成できなくする

    [Header("敵を生成する際のエフェクト")]
    public GameObject createEffect;


    [Header("プレイヤーのオブジェクトを挿入（座標位置が知りたいため）")]
    public GameObject player;
    public float createPositionDistance;

    [Header("作成乱数の最大値")]
    public float RandomMax = 100;

    [Header("乱数で取得した数値がこの数値以下なら敵を生成")]
    [SerializeField]
    private float RandomCreate = 1;

    [Header("以下座標計算")]
    private const int mapSlice = 10;
    public int cellSize;

    private void Start()
    {
        //今のところ処理なし
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
                //配列の要素が空いていた場合、敵を生成する。
                if (!GoEnemy[i])
                {
                    GameObject go = Instantiate(EnemyPrefab[EnemyNum], SetPos10x10z(i), transform.rotation);
                    GoEnemy[i] = go;//敵を配列に保存
                    createFlag = true;
                }
            }
        }
    }

    public Vector3 SetPos10x10z(int for_I)
    {
        //敵を生成するための座標をマス目として宣言する
        float[] posX = new float[mapSlice];
        float[] posZ = new float[mapSlice];
        //スライスを行い、座標計算
        for (int i = 0; i < mapSlice; ++i)
        {
            posX[i] = ((-(mapSlice / 2) + i) * cellSize) + (cellSize / 2);
            posZ[i] = ((-(mapSlice / 2) + i) * cellSize) + (cellSize / 2);
        }

        //乱数で取得した値がプレイヤーと重ならない位置になるまでループ
        bool loopFlag = true;
        int randomX = 0, randomZ = 0;
        while (loopFlag)
        {
            //最後にfor文で判定を行うため一度無限ループを無効化
            loopFlag = false;

            //生成するマス目の値をランダムで取得
            randomX = Random.Range(0, mapSlice);
            randomZ = Random.Range(0, mapSlice);
            //プレイヤーの現在の座標を取得
            float pPosMinX = player.transform.position.x - createPositionDistance;
            float pPosMaxX = player.transform.position.x + createPositionDistance;
            float pPosMinZ = player.transform.position.z - createPositionDistance;
            float pPosMaxZ = player.transform.position.z + createPositionDistance;

            //プレイヤーの座標が敵生成予定地の周辺だった場合は再度ループを行う
            for (int x = -1; x <= 1 && loopFlag == false; ++x) { 
                for (int z = -1; z <= 1; ++z){//二重ループ
                    if (randomX + x >= 0 && randomX + x < mapSlice){//オーバーラン防止
                        if (randomZ + z >= 0 && randomZ + z < mapSlice){//オーバーラン防止
                            if(pPosMinX <= posX[randomX] && posX[randomX] <= pPosMaxX){//プレイヤー付近の場合
                                if (pPosMinZ <= posZ[randomZ] && posZ[randomZ] <= pPosMaxZ)//プレイヤー付近の場合
                                {
                                    //再度ループ
                                    loopFlag = true;
                                }
                            }
                        }
                    }
                }
            }

            //他の敵と座標がかぶっている場合、再度ループ
            for(int i = 0; i < CreateEnemyMax; ++i)
            {
                if(i != for_I)//自身の番号と異なる場合
                {
                    if (GoEnemy[i])
                    {
                        if (GoEnemy[i].transform.position.x / cellSize ==
                            randomX)//X座標番号が同じ場合
                        {
                            if (GoEnemy[i].transform.position.y / cellSize ==
                                randomZ)//Z座標番号が同じ場合
                            {
                                loopFlag = true;//再度ループ
                            }
                        }
                    }
                }
            }

        }

        //エフェクト生成
        GameObject effect = Instantiate(createEffect);
        effect.transform.position = new Vector3(posX[randomX], 0, posZ[randomZ]);
        return new Vector3(posX[randomX], 0, posZ[randomZ]);
    }
}
