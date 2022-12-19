using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSchedule : MonoBehaviour
{
    [Header("テキスト参照"), SerializeField]
    private Text textObject;
    [Header("ボックスのコントローラー"), SerializeField]
    private TextboxControl textboxControl;
    [Header("右クリックマウス画像"), SerializeField]
    private GameObject mouseRight;

    [System.Serializable]
    public struct Schedule
    {
        public string writeText;
        public TutorialChecker checker;
        public bool msRightClick;
    }
    [Header("表示したいテキストと表示時間(毎回０秒から計測)(条件を付ける場合は条件を書いたスクリプトを挿入)")]
    public Schedule[] schedules = new Schedule[1];
    [SerializeField]
    public int scheduleNum;

    // Start is called before the first frame update
    void Start()
    {
        scheduleNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (scheduleNum < schedules.Length)
        {
            textObject.text = schedules[scheduleNum].writeText;

            mouseRight.SetActive(schedules[scheduleNum].msRightClick);

            //処理有効化
            if (schedules[scheduleNum].checker)
            {
                schedules[scheduleNum].checker.enabled = true;
            }

            //テキストページ送り
            TextPage();

        }
    }

    public void TextPage()
    {
        //右クリックでページ
        bool pageNextFlag = Input.GetMouseButtonDown(1);
        
        //処理が参照されている場合
        if (schedules[scheduleNum].checker)
        {
            //クリックフラグが無効化されている場合
            if (!schedules[scheduleNum].msRightClick)
            {
                //処理のflagでページ送りを判定
                pageNextFlag = schedules[scheduleNum].checker.flag;
            }
        }

        //右クリック　＆　条件を満たしている場合
        if (pageNextFlag)
        {
            //テキストボックスを駆動
            textboxControl.SetFlag(true);
            //テキストを消す
            textObject.text = "";

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
