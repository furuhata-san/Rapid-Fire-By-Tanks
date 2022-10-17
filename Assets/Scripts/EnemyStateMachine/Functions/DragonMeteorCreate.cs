using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMeteorCreate : EnemyStateFunction
{
    [Header("隕石プレファブ")]
    public GameObject meteorObject;
    public Vector2Int createValues;

    [Header("隕石生成時、鳴らす効果音")]
    public AudioSource createAudio;

    [Header("プレイヤーを探す（プレイヤ名）")]
    public string playerObjectName;
    private GameObject player;//プレイヤーを自動検索、格納する

    //下記二つの時間が違う場合、フラグを有効化する
    private float afterTime;//現在の時間
    private float beforeTime;//前回の時間
    private bool meteorCreateFlag;//trueなら隕石を生成する

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
          Enableの場合のみ::カウントが前回と変わっていない場合、
          stateが呼び出されていないため、再度有効化させる。
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
        //プレイヤの位置に隕石生成
        Vector3 pPos = player.transform.position;
        MeteorGenerator(new Vector3(pPos.x, 0, pPos.z));
    }

    private void CreateMeteorRandom()
    {
        //隕石を生成するための座標をマス目として宣言する
        const int mapSlice = 10;
        const float cellSize = 10;

        float[] posX = new float[mapSlice];
        float[] posZ = new float[mapSlice];
        //スライスを行い、座標計算
        for (int i = 0; i < mapSlice; ++i)
        {
            posX[i] = ((-(mapSlice / 2) + i) * cellSize) + (cellSize / 2);
            posZ[i] = ((-(mapSlice / 2) + i) * cellSize) + (cellSize / 2);
        }

        //マス目の値をランダムで取得
        int randomX = Random.Range(0, mapSlice);
        int randomZ = Random.Range(0, mapSlice);

        //隕石生成
        MeteorGenerator(new Vector3(posX[randomX], 0, posZ[randomZ]));
    }

    private void MeteorGenerator(Vector3 pos)
    {
        GameObject go = Instantiate(meteorObject);
        go.transform.position = pos;
    }
}
