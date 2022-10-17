using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCanonController : MonoBehaviour
{
    [Header("�U��������x")]
    [SerializeField]
    private float speed;
    private float step;

    public void TankCanonMove(Vector3 target)
    {        
        //���x�v�Z�ideltaTime�j
        step = speed * Time.deltaTime;

        //���g���猩�āA�^�[�Q�b�g���ǂ��̈ʒu�ɂ��邩
        Vector3 targetDir = target - transform.position;

        //�ݒ肵�����x�ŕ␳���Ȃ���C��̉�]�ʂ����߂�
        Vector3 moveDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0f);

        //��]
        transform.rotation = Quaternion.LookRotation(moveDir);
    }
}
