using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toplay4 : MonoBehaviour
{
    public Transform[] Filled3;
    public Animator Anim;
    public GameObject changeScene;
  

    // Start is called before the first frame update
    void Start()
    {
        changeScene.SetActive(false);
   
    }

    // Update is called once per frame
    void Update()
    {
        if (Filled3[0] == null &&
           Filled3[1] == null &&
           Filled3[2] == null &&
           Filled3[3] == null)
        {
            Anim.SetBool("butterfly", true);
            changeScene.SetActive(true);
        }
    }
}
