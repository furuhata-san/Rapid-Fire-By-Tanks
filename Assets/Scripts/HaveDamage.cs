using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveDamage : MonoBehaviour
{
    [SerializeField]
    private int damage = 0;//ダメージの増減はなし

    public int GetDamage()
    {
        return damage;
    }
}
