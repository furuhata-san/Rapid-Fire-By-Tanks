using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveDamage : MonoBehaviour
{
    [Header("ダメージ消滅時間")]
    [SerializeField]
    private float damageOffTime = 9999.0f;

    [Header("ダメージ")]
    [SerializeField]
    private int damage = 0;

    public int GetDamage()
    {
        return damage;
    }

    void Update()
    {
        damageOffTime -= Time.deltaTime;
        if(damageOffTime <= 0)
        {
            damage = 0;
        }
    }
}
