using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugKey : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //ゲーム終了
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        //シーン移行
        //else if (Input.GetKeyDown(KeyCode.F1)) SceneManager.LoadScene("Title");
        //else if (Input.GetKeyDown(KeyCode.F2)) SceneManager.LoadScene("Game");
        //else if (Input.GetKeyDown(KeyCode.F3)) SceneManager.LoadScene("Tutorial");
        //else if (Input.GetKeyDown(KeyCode.F4)) SceneManager.LoadScene("Result");
        //マウスの表示変更
        else if (Input.GetKeyDown(KeyCode.F9)) Cursor.visible = true;
        else if (Input.GetKeyDown(KeyCode.F10)) Cursor.visible = false;
    }
}
