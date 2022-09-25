using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{
    [Header("���̃I�u�W�F�N�g���Q�Ƃ���I�u�W�F�N�g")]
    public Camera MainCamera;
    public GameObject ShotBullet;
    public Image aimImage;

    [Header("���݁A�J�[�\�����w���Ă���G�̏����R�s�[����I�u�W�F�N�g")]
    public LifeAndUIMgr[] lifeAndUI = new LifeAndUIMgr[1];

    [HideInInspector]
    public Vector3 targetPos;

    public RaycastHit msHit;
    public RaycastHit blHit;



    void Update()
    {
        // �}�E�X�̈ʒu��Ray���΂��B���ق��̃X�N���v�g�Ŏg�p
        Vector2 msPos = Input.mousePosition;
        Ray msRay = Camera.main.ScreenPointToRay(msPos);
        Physics.Raycast(msRay, out msHit);

        //�C��̌�����Ray���Ƃ΂��A�q�b�g���邩���v�Z����
        Ray blRay = new Ray(ShotBullet.transform.position, ShotBullet.transform.forward);
        if (Physics.Raycast(blRay, out blHit))
        {
            // Ray��Collider�ƏՓ˂����n�_�̍��W���擾
            targetPos = blHit.point - ShotBullet.transform.position;

            //�^�[�Q�b�g�����C���J�����̂ǂ��ɕ\������Ă��邩���擾
            Vector2 pos2D = RectTransformUtility.WorldToScreenPoint(Camera.main, blHit.point);
            transform.position = pos2D;

            if (blHit.transform.CompareTag("Enemy"))
            {
                //�̗͂��Q�Ƃ���G��ύX
                EnemyBase ebase = blHit.transform.gameObject.GetComponent<EnemyBase>();
                
                //�G�̏���ʃX�N���v�g�ɓn��
                for (int i = 0; i < lifeAndUI.Length; ++i)
                {
                    lifeAndUI[i].ebase = blHit.transform.gameObject.GetComponent<EnemyBase>();
                }

                if (ebase.GetLifeNow() > 0)//�G�̃��C�t���[���ȉ��ł͂Ȃ��ꍇ
                {
                    // �Ə����ԐF�ɕω�������B
                    aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                }
                else
                {
                    // �Ə���̐F�͔�
                    aimImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
            }
            else
            {
                // �Ə���̐F�͔�
                aimImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }
}
