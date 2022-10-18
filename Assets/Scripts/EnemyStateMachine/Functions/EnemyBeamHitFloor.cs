using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeamHitFloor : EnemyStateFunction
{
    [Header("��������G�t�F�N�g�Ɛ����Ԋu")]
    [SerializeField]
    private GameObject effect;
    [SerializeField]
    private float craeteInterval;
    private float nowCreateCount;

    // Start is called before the first frame update
    void Start()
    {
        nowCreateCount = 0;
    }

    // Update is called once per frame
    public override EnemyStateMachine.State EnemyMove(float tdt)
    {
        //�J�E���g����
        nowCreateCount += tdt;
        return EnemyStateMachine.State.Now;
    }

    private void OnTriggerStay(Collider other)
    {
        //�G�t�F�N�g���������𒴂�����
        if (nowCreateCount >= craeteInterval)
        {
            //Ray�𔭎˂��A���e�n�_�ɃG�t�F�N�g��\��
            Ray machineBeam = new Ray(this.transform.position, this.transform.up);
            RaycastHit beamHit;
            if(Physics.Raycast(machineBeam, out beamHit))
            {
                if (beamHit.transform.name == "Plane")
                {
                    // Ray��Collider�ƏՓ˂����n�_�̍��W���擾
                    Vector3 targetPos = beamHit.point;

                    //�G�t�F�N�g����
                    GameObject go = Instantiate(effect);
                    effect.transform.position = targetPos;
                }
            }

            //�J�E���g����
            nowCreateCount -= craeteInterval;
        }
    }
}