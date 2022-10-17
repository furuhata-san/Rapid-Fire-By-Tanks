using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TurretsTeam : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (!HasChild(this.gameObject))
        {
            Destroy(gameObject);
        }
    }

    public bool HasChild(GameObject gameObject)
    {
        return 0 < gameObject.transform.childCount;
    }
}
