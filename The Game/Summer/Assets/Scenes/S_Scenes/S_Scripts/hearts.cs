using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearts : MonoBehaviour
{
    public Animator heartdestroy;

    
    void Update()
    {
        { Destroy(GameObject.Find("heart" + Eachmonster.ouch)); }

       // if (Eachmonster.ouch==3)
        //{}
    }
}
