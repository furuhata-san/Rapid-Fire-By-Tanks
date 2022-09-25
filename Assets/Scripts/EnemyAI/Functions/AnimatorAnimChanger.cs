using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAnimChanger : EnemyStateFunction
{
    [Header("死亡時、変更したいアニメーションのトリガー名")]
    public string animTriggerName;

    [Header("アニメーターを参照（挿入されていない場合は自動検索を行う）")]
    private Animator animator;
    private bool firstFlag;

    public enum AnimPlayMode
    {
        Once,
        Enable,
        AllTime,
        Non,
    };
    [Header("アニメーション更新の方法")]
    public AnimPlayMode playMode;

    //[Enableのみ]
    //下記二つの時間が違う場合、フラグを有効化する
    private float afterTime;//現在の時間
    private float beforeTime;//前回の時間

    // Start is called before the first frame update
    void Start()
    {
        firstFlag = true;
        //アニメーターが参照されていなかった場合
        if (!animator)
        {
            //アニメーターを自動検索
            animator = this.GetComponent<Animator>();
        }
        afterTime = 0;
        beforeTime = 0;
    }

    private void Update()
    {
        /*
        Enableの場合のみ::カウントが前回と変わっていない場合、
        stateが呼び出されていないため、再度有効化させる。
        */    
        if (playMode == AnimPlayMode.Enable)
        {
            if (afterTime == beforeTime)
            {

                firstFlag = true;
            }
            else
            {
                afterTime = beforeTime;
            }
        }
    }

    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        afterTime += Time.deltaTime;

        //モードによって処理変更
        switch (playMode)
        {
            case AnimPlayMode.Once:
                if (!firstFlag) return EnemyStateMachine.State.Now;
                firstFlag = false;
                break;

            case AnimPlayMode.Enable:
                if (!firstFlag) return EnemyStateMachine.State.Now;
                firstFlag = false;
                break;

            case AnimPlayMode.Non:
                Debug.Log("アニメーションが無効状態です。");
                return EnemyStateMachine.State.Now;

            default:
                break;
        }

        //アニメーションを更新
        animator.SetTrigger(animTriggerName);

        return EnemyStateMachine.State.Now;
    }
}
