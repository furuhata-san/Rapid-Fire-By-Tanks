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
    [Header("警告:このゲームオブジェクトを参照オブジェクトにしないこと")]
    public Schedule[] schedule = new Schedule[1];
    
    private float Timer;
    private int scheduleNum;

    // Start is called before the first frame update
    void Start()
    {
        //情報の初期化
        Timer = 0;
        scheduleNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //時間の追加
        Timer += Time.deltaTime;

        //スケジュールの時間を過ぎていたら
        if(schedule[scheduleNum].time <= Timer)
        {
            //ゲームオブジェクトを有効化
            ObjectActive(schedule[scheduleNum].gameObject, true);
            //タイマーリセット
            Timer = 0;
            //スケジュールを変更
            ++scheduleNum;
        }

        //スケジュールがこれ以上ない場合ゲームオブジェクトを破棄
        if (scheduleNum >= schedule.Length) Destroy(gameObject);

    }

    void ObjectActive(GameObject go, bool flag)
    {
        go.SetActive(flag);
    }

}
