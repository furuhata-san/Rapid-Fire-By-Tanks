using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHeadController : MonoBehaviour
{
    [Header("��]���x")]
    [SerializeField]
    private float speed;
    private float step;

    public void TankHeadMove(Vector3 target)
    {
        //Y���̉�]�͂Ȃ��i�C��Ɉ�C�j
        target.y = transform.position.y;
        
        //�ړ����x�����߂�ideltaTime�j
        step = speed * Time.deltaTime;

        //�^�[�Q�b�g�����g����ǂ��̈ʒu�ɂ��邩���v�Z
        Vector3 targetDir = target - transform.position;

        //���߂������g�p���ĉ�]�ʂ��v�Z
        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);
        
        //��]
        transform.rotation = Quaternion.LookRotation(moveDir);
    }
}
