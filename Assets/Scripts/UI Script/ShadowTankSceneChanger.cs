using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadowTankSceneChanger : MonoBehaviour
{
    private bool moveFlag = false;
    public float AddForce = 100.0f;
    public string sceneName;

    void Update()
    {
        if (moveFlag)
        {
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();  // rigidbody���擾
            Vector2 force = new Vector2(-(AddForce * Time.deltaTime), 0.0f);    // �͂�ݒ�
            rb.AddForce(force, ForceMode2D.Force);            // �͂�������
        }
    }

    //�g���K�[�ł͂Ȃ������蔻��i���j
    public void OnCollisionEnter2D(Collision2D collision)
    {
        moveFlag = true;
    }

    //��Ԃ̒��S�ɂ���g���K�[�����ꂽ����i�X�C�b�`�̂悤�Ȃ��́j
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //�󂾂����ꍇ�̓A�v���I��
        if (sceneName == "")
        {
            Application.Quit();
        }
        //�V�[��������ł͂Ȃ��ꍇ�̓V�[���ύX
        else
        {
            SceneLoading(sceneName);
        }
    }

    public void SceneLoading(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Set_SceneName(string name)
    {
        sceneName = name;
    }

    public bool GetState()
    {
        return moveFlag;
    }
}
