using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FollowTheEnemy : MonoBehaviour
{
    [Header("���̃I�u�W�F�N�g�ɃA�^�b�`����Ă���̗͊Ǘ��̃}�l�[�W���[")]
    public LifeAndUIMgr LUM;

    //�Q�Ƃ���G�l�~�[
    private EnemyBase ebase;


    // Start is called before the first frame update
    void Start()
    {
        //�ŏ��͉�ʊO
        transform.position = new Vector2(-2000, -2000);
    }

    // Update is called once per frame
    void Update()
    {
        ebase = LUM.ebase;
        //�G�����݂����Ă���ꍇ�A�̗͂�\��
        if (ebase)
        {
            // �v���C���[�̃X�N���[�����W�i2D�j���擾
            Vector3 screen = RectTransformUtility.WorldToScreenPoint(Camera.main, ebase.transform.position);
            // �\������菭����ɃQ�[�W���\�������悤�ɂ���
            float up = 100;
            // �Q�[�W�̍��W��ݒ�
            Vector3 trans = this.gameObject.transform.position;
            trans.x = screen.x;
            trans.y = screen.y + up;
            this.gameObject.transform.position = trans;
        }
        else
        {
            //��ʊO
            transform.position = new Vector2(-2000, -2000);
        }
    }
}
