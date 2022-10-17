using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightOf : EnemyStateFunction
{
    [Header("�v���C���[�̋������w�苗����藣�ꂽ���ԕω�")]
    [SerializeField]
    private float distance;

    [Header("�Q�Ƃ���I�u�W�F�N�g��")]
    [SerializeField]
    private string targetName;
    private GameObject target;
    private Vector3 targetPosBefore;

    [Header("���̏��")]
    [SerializeField]
    private EnemyStateMachine.State nextState;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find(targetName);
    }

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //���g���猩�������̌v�Z
        Vector3 dir = transform.position - target.transform.position;
        
        //����������Ă������ԕύX
        if(dir.magnitude >= distance)
        {
            return nextState;
        }
        return EnemyStateMachine.State.Now;
    }
}
