using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackObjectSwitch : EnemyStateFunction
{
    [Header("�r�[���I�u�W�F�N�g��}��")]
    public GameObject beamGameObject;

    [Header("���݂̏��")]
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
