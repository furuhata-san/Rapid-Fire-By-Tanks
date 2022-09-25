using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�������Z
    private Rigidbody rigid;

    [Header("�Q�Ƃ���X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g��}��")]
    public TankHeadController thc;
    public TankCanonController tcc;
    public AimController acz;

    [Header("�v���C���[�̓���̑��x����")]
    public float rotateForce;
    public float runSpeed;
    public float maxSpeed;

    //�O�i���
    void Run(float tdt)
    {
        float key_ud = Input.GetAxis("Vertical");
        Vector3 vel_xz = new Vector3(rigid.velocity.x, 0, rigid.velocity.z);
        //���͂��s���Ă��邩�ō����x�łȂ���Έړ�
        if (key_ud > 0.01f || key_ud < -0.01f)
        {
            if (vel_xz.magnitude < maxSpeed)
            {
                rigid.AddForce(transform.forward * Input.GetAxis("Vertical") * runSpeed * tdt);
            }
        }
    }

    //��]
    void turn(float tdt)
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateForce * tdt, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //�������Z������Ă��Ȃ��ꍇ�͏������s��Ȃ�
        if (rigid == null) return;

        //�O��̃t���[���Ƃ̎��ԍ����擾
        float tdt = Time.deltaTime;

        //�}�E�X�̌��݈ʒu���擾
        Vector3 MousePos = acz.msHit.point;
        
        //�C���]
        thc.TankHeadMove(MousePos);

        //�C����]
        tcc.TankCanonMove(MousePos);

        //���͂ɂ���ăv���C����Y����]
        turn(tdt);

        //�O�i���
        Run(tdt);
    }
}
