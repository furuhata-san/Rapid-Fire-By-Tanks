using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveDamage : MonoBehaviour
{
    [SerializeField]
    private int damage = 0;//�_���[�W�̑����͂Ȃ�

    public int GetDamage()
    {
        return damage;
    }
}
