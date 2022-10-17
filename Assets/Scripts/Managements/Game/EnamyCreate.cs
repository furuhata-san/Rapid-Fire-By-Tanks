using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamyCreate : MonoBehaviour
{
    [Header("生産したいエネミーのPrafabをセット")]
    public GameObject[] EnemyPrefab = new GameObject[1];

    public GameObject[] GoEnemy = new GameObject[1];//敵を最大数以上生成できなくする

    [Header("敵を生成する際のエフェクト")]
    public GameObject createEffect;


    [Header("プレイヤーのオブジェクトを挿入（座標位置が知りたいため）")]
    public GameObject player;

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
            //敵を１体だけ生成する
            bool createFlag = false;
            int EnemyNum = Random.Range(0, EnemyPrefab.Length);
            for (int i = 0; i < GoEnemy.Length && !createFlag; ++i)
            {
                //配列の要素が空いていた場合、敵を生成する。
                if (!GoEnemy[i])
                {
                    GameObject go = Instantiate(EnemyPrefab[EnemyNum], SetPosSlicePos(i), transform.rotation);
                    GoEnemy[i] = go;//敵を配列に保存
                    createFlag = true;
                }
            }
        }
    }

    public Vector3 SetPosSlicePos(int for_I)
    {
        //敵を生成するための座標をマス目として宣言する
        float[] posX = new float[mapSlice];
        float[] posZ = new float[mapSlice];
        //スライスを行い、座標計算
        for (int i = 0; i < mapSlice; ++i)
        {
            //マップ左端(-4～5) => 0は中心の左上（Z軸が正面方向を向いている場合）
            //マップ左端から現在の番号(i)分を減算し、マス目中心（１マスの半分）を代入する
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

            //生成するマス目の要素番号をランダムで取得
            randomX = Random.Range(0, mapSlice);
            randomZ = Random.Range(0, mapSlice);

            //プレイヤーの現在の座標を取得し、サイズをマス目分拡大
            //(マス目の中心にいた場合は生成しない、端にいた場合は生成する)
            float PlayerAreaSize = cellSize * 1.75f;
            float pPosMinX = player.transform.position.x - PlayerAreaSize;
            float pPosMaxX = player.transform.position.x + PlayerAreaSize;
            float pPosMinZ = player.transform.position.z - PlayerAreaSize;
            float pPosMaxZ = player.transform.position.z + PlayerAreaSize;

            //以下プレイヤー、もしくはすでに存在している敵と重なっていないかの判定を行う。
            //フラグがtrueになった瞬間判定を終了する

            //プレイヤーの座標が敵生成予定地の周辺だった場合は再度ループを行う（XZ軸を使用した２Ｄの矩形の当たり判定）
            ///（二重ループ削除）
            if (pPosMinX <= posX[randomX] && posX[randomX] <= pPosMaxX)
            {//プレイヤー付近の場合（Ｘ）
                if (pPosMinZ <= posZ[randomZ] && posZ[randomZ] <= pPosMaxZ)//プレイヤー付近の場合（Ｚ）
                {
                    //再度ループ
                    loopFlag = true;//(for文終了)
                }
            }



            //他の敵と座標がかぶっている場合、再度ループ
            for(int i = 0; i < GoEnemy.Length && loopFlag == false; ++i)
            {
                if(i != for_I)//自身の番号と異なる場合
                {
                    if (GoEnemy[i])//敵が生成されている場合
                    {
                        if ((GoEnemy[i].transform.position.x - posX[0]) / cellSize == randomX)//X座標番号が同じ場合
                        {
                            if ((GoEnemy[i].transform.position.z - posZ[0]) / cellSize == randomZ)//Z座標番号が同じ場合
                            {
                                //再度ループ
                                loopFlag = true;//for文終了
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
