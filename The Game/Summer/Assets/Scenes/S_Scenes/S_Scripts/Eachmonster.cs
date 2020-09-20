using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eachmonster : MonoBehaviour
{
    //public Animator supermanflinch;
    public static int ouch = 0;
    void Start()
    {
        ouch = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
     ouch++;
     FindObjectOfType<AudioManager>().Play("Monsters");
  // Destroy(gameObject, 0.1f);
     //GetComponent<BoxCollider2D>().enabled = false;
    }
    
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.025f);
        if (Eachmonster.ouch == 3)
        { Destroy(gameObject); }
    }
}
