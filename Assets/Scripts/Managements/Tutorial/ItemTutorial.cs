using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTutorial : MonoBehaviour
{
    public GameObject Item;
    public int num = 1;

    // Start is called before the first frame update
    void Start()
    {
        Item.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
