using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackObjectSwitch : EnemyStateFunction
{
    [Header("ビームオブジェクトを挿入")]
    public GameObject beamGameObject;

    [Header("現在の状態")]
    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        beamGameObject.SetActive(false);
    }

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        beamGameObject.SetActive(active);
        return EnemyStateMachine.State.Now;
    }
}
