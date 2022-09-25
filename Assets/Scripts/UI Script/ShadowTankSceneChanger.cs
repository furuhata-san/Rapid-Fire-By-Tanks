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
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();  // rigidbodyを取得
            Vector2 force = new Vector2(-(AddForce * Time.deltaTime), 0.0f);    // 力を設定
            rb.AddForce(force, ForceMode2D.Force);            // 力を加える
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        moveFlag = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        SceneLoading(sceneName);
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
