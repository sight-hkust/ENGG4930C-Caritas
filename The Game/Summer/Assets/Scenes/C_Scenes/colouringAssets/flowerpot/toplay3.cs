using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toplay3 : MonoBehaviour
{
    public Transform[] Filled;
   
    public GameObject changeScene;
    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        changeScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Filled[0] == null &&
            Filled[1] == null &&
            Filled[2] == null &&
            Filled[3] == null)
        { 
            Anim.SetBool("play", true);
            //FindObjectOfType<AudioManager>().Play("FlowersBloom");
            changeScene.SetActive(true);
        }
       

    }
}
