using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class final : MonoBehaviour
{
    public Animator Anim;
    public Sprite[] characterflying;
    public GameObject Back;
    public string scene;
    void Start()
    {
        Back.SetActive(false);
    }
    void Update()
    {
        
        if (star.collected + star.lost == 20 || Eachmonster.ouch==3)
        { Anim.SetBool("Superzoom", true);
          Back.SetActive(true);

           // star.collected=0;
           // star.lost = 0;
           
         }
        GetComponent<SpriteRenderer>().sprite = characterflying[next.change - 1];
        
    }
   // void Loadscene()
   // { SceneManager.LoadScene("Stats"); }
}
