using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotation : MonoBehaviour
{ void OnMouseDown()
    {
        if (!GameManage.youWin || !GameManage.youWin2)
        { transform.Rotate(0, 0, 90f) ; }
    }
    
}
