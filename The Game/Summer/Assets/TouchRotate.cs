using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{ void OnMouseDown()
    {
        if (!GameControl.youWin || !GameControl.youWin2)
        { transform.Rotate(0, 0, 90f) ; }
    }
    
}
