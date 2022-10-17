using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickEffectMgr : MonoBehaviour
{
    [Header("カーソルImageをHierarchyから持ってくる")]
    [SerializeField]
    private Image cursorImage;

    [Header("生成するImageのPrefab")]
    [SerializeField]
    private Image imagePrefab;

    [Header("親オブジェクトとなるCanvas")]
    [SerializeField]
    private Canvas canvas;

    [Header("フェードアウト中はカーソル非表示（なくても可）")]
    [SerializeField]
    private GameObject fadeOut;

    // Update is called once per frame
    void Update()
    {
        //フェードが参照されている
        if (fadeOut)
        {
            //フェード中
            if (fadeOut.activeSelf == true)
            {
                //カーソルイメージ無効化
                cursorImage.gameObject.SetActive(false);
            }
            else
            {
                //カーソルの位置変更
                cursorImage.transform.position = Input.mousePosition;
                //エフェクト生成
                CreateEffect();
            }
        }
        //フェードが参照されていない
        else
        {
            //カーソルの位置変更
            cursorImage.transform.position = Input.mousePosition;
            //エフェクト生成
            CreateEffect();
        }
    }

    private void CreateEffect()
    {
        //クリック時にエフェクト生成
        if (Input.GetMouseButtonDown(0))
        {
            Image eff = Instantiate(imagePrefab);
            eff.transform.SetParent(canvas.transform);
            eff.transform.position = cursorImage.transform.position;
        }
    }
}
