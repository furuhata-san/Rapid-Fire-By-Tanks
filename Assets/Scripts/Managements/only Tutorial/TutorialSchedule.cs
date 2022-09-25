using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSchedule : MonoBehaviour
{
    public GameObject textGameObject;
    public TextboxControl textboxControl;
    private Text textData;

    [System.Serializable]
    public struct Schedule
    {
        public string writeText;
        public float writeTime;
        public TutorialChecker checker;
    }
    [Header("表示したいテキストと表示時間(毎回０秒から計測)(条件を付ける場合は条件を書いたスクリプトを挿入)")]
    public Schedule[] schedules = new Schedule[1];
    [SerializeField]
    public int scheduleNum;
    public float textTimer;

    // Start is called before the first frame update
    void Start()
    {
        scheduleNum = 0;
        textTimer = 0;
        textData = textGameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scheduleNum < schedules.Length)
        {
            textData.text = schedules[scheduleNum].writeText;

            if (schedules[scheduleNum].checker)
            {
                schedules[scheduleNum].checker.enabled = true;
                //判定がtrueになったら時間を加算
                if (schedules[scheduleNum].checker.GetFlag())
                {
                    timerUpdate();
                }
            }
            else
            {
                //時間を加算
                timerUpdate();
            }

            //早送り
            if (Input.GetMouseButtonDown(1))
            {
                if (schedules[scheduleNum].checker)
                    schedules[scheduleNum].checker.flag = true;
                textTimer = 999.0f;
            }
        }
    }

    public void timerUpdate()
    {
        textTimer += Time.deltaTime;

        //表示時間を超えていたら
        if (schedules[scheduleNum].writeTime <= textTimer)
        {
            //テキストボックスを駆動
            textboxControl.SetFlag(true);
            //テキストを消す
            textData.text = "";
            //時間を初期化
            textTimer = 0;
            //判定スクリプトがある場合、軽くする＆バグ防止のため無効化
            if (schedules[scheduleNum].checker)
            {
                schedules[scheduleNum].checker.enabled = false;
            }
            //次のスケジュールへ
            ++scheduleNum;
        }
    }
}
