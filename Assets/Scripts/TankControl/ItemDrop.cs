using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [Header("�h���b�v���������A�C�e��Prefab")]
    public GameObject obj;

    [Header("�h���b�v��")]
    [SerializeField]
    private int range = 100;
    [SerializeField]
    private int probability = 1;

    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(0,range) <= probability)
        {
            //��]�ʂ��Ɍv�Z
            float rX = Random.Range(0.0f, 360.0f);
            float rY = Random.Range(0.0f, 360.0f);
            float rZ = Random.Range(0.0f, 360.0f);
            Instantiate(obj,
                new Vector3(transform.position.x, 1.0f, transform.position.z),
                Quaternion.Euler(0, Random.Range(0.0f, 360.0f), 0));
        }
    }

}
