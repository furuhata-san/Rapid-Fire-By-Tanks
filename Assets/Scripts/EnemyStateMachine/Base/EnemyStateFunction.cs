using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateFunction : MonoBehaviour
{
    /*
        Vigilance,  //�x�����[�h
        PlayerFind, //�����E�U�����[�h
        EnemyDie, //�폜���[�h
    */

    public virtual EnemyStateMachine.State EnemyMove(float tdt)
    {
        //�I�[�o�[���C�h�p
        return EnemyStateMachine.State.Non;
    }
}
