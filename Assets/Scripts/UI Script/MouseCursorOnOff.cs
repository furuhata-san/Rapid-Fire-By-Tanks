using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorOnOff : MonoBehaviour
{
    [SerializeField]
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = flag;
    }

}
