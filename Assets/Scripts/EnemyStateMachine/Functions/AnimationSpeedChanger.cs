using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationSpeedChanger : EnemyStateFunction
{
    [Header("ナビメッシュの移動速度に応じてアニメーションの再生速度を変更")]
    [SerializeField]
    private Animator[] animator = new Animator[1];
    [Header("アニメーション速度変更割合")]
    [SerializeField]
    private float animSpeedVal;
    [Header("ナビメッシュの速度によって変更を行う")]
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //現在の移動速度のベクトル
        Vector3 nowSpeed = navMeshAgent.velocity;
        float nowMoveSpeed = nowSpeed.magnitude;

        for (int i = 0; i < animator.Length; ++i)
        {
            animator[i].speed = nowMoveSpeed * animSpeedVal;
        }

        //変更はしない
        return EnemyStateMachine.State.Now;
    }
}
