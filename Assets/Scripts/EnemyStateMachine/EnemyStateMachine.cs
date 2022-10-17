using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : EnemyBase
{
    //ステートマシン関数
    public enum State
    {
        Vigilance,  //警戒モード
        PlayerFind, //発見・攻撃モード
        EnemyDie, //削除モード

        //以下の状態になった場合は不正
        Now,        //現在の状態を維持（状態ではない）
        Non,        //無効（初期）
    }
    [HideInInspector]
    public State nowState;
    [Header("初期化時にセットする状態（初期値）")]
    public State firstState;
    [Header("エネミーが攻撃を受けた場合、即時に敵発見状態へ移行する")]
    public bool discoveredWhenAttacked;
    private int saveLifeValue;

    [Header("行動がアタッチされたスクリプト\n状態が変更された場合（Now以外）、以降の処理は行うが状態の変化は行わない。\n(状態変化の優先度は下のスクリプトが最も高い)")]
    public EnemyStateFunction[] esfVigilance = new EnemyStateFunction[1];
    public EnemyStateFunction[] esfPlayerFind = new EnemyStateFunction[1];
    public EnemyStateFunction[] esfEnemyDie = new EnemyStateFunction[1];

    // Start is called before the first frame update
    void Start()
    {
        nowState = firstState;
        saveLifeValue = GetLifeNow();
    }

    // Update is called once per frame
    void Update()
    {
        float tdt = Time.deltaTime;
        StateMachine(tdt);

        if (discoveredWhenAttacked)
        {
            if (!JudgeEnemyDie())
            {
                if (saveLifeValue != GetLifeNow())
                {
                    nowState = State.PlayerFind;
                }
            }
            saveLifeValue = GetLifeNow();
        }
    }

    void StateMachine(float tdt)
    {
        State stateChecker = State.Now;//関数の戻り値を保存
        State nextState = State.Now;//戻り値がNow以外の場合はその値を保存し、寿命が尽きるまで別の値を保存しなくなる

        switch (nowState)
        {
            case State.Vigilance:
                for (int i = 0; i < esfVigilance.Length; ++i)
                {
                    stateChecker = esfVigilance[i].EnemyMove(tdt);
                    if (stateChecker != State.Now) { nextState = stateChecker; }
                }
                break;

            case State.PlayerFind:
                for (int i = 0; i < esfPlayerFind.Length; ++i)
                {
                    stateChecker = esfPlayerFind[i].EnemyMove(tdt);
                    if (stateChecker != State.Now) { nextState = stateChecker; }
                }
                break;

            case State.EnemyDie:
                DieStart();//最初の一回だけ処理を行う
                for (int i = 0; i < esfEnemyDie.Length; ++i)
                {
                    stateChecker = esfEnemyDie[i].EnemyMove(tdt);
                    if (stateChecker != State.Now) { nextState = stateChecker; }
                }
                break;

            default:
                Debug.LogError("不正な状態です：" + nowState);
                break;
        }

        if (JudgeEnemyDie())
        {
            nextState = State.EnemyDie;
        }


        //現在の状態を維持しない場合（Now以外の場合）
        if (nextState != State.Now)
        {
            //状態変更
            nowState = nextState;
        }
    }

    void DieStart()
    {
        if (!firstDied) return;

        //スコア加算
        if(ScoreMgr) ScoreMgr.AddScore(score);
        
        //当たり判定削除（貫通させる）
        Destroy(this.GetComponent<Collider>());
        
        //Rayがヒットしないように(エイムカーソルがヒット判定を行わない)
        this.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        
        //死亡時にならすオーディオがあれば鳴らす
        if (dieAudioSource) dieAudioSource.Play();

        //フラグをオフに
        firstDied = false;
    }
}
