using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toplay2 : MonoBehaviour
{
    public Transform[] AllGone;
    public Animator Anim;
    public Animator Steam;
    public GameObject changeScene;
    // Start is called before the first frame update
    void Start()
    {
        changeScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (AllGone[0] == null &&
            AllGone[1] == null &&
            AllGone[2] == null &&
            AllGone[3] == null)
        {Anim.SetBool("train", true);
         Steam.SetBool("steam", true);
           // FindObjectOfType<AudioManager>().Play("TrainStarts");
            changeScene.SetActive(true);
        }
    }
}
