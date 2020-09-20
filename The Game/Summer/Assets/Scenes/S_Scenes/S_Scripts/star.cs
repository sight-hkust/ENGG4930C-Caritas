using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class star : MonoBehaviour
{
    public static bool Gotit=false;
    public static int collected=0;
    public static int lost = 0;

    void Start()
    {
        collected = 0;
    }
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.025f); ;
        if (transform.position.y < -10f)
        {
            lost++;
            Destroy(gameObject);
        }
        if (Eachmonster.ouch==3)
        { Destroy(gameObject); }
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        transform.localScale = new Vector2(1.1f, 1.1f);
        Destroy(gameObject, 0.1f);
        Gotit = true;
        collected++;
        FindObjectOfType<AudioManager>().Play("Stars");
        Debug.Log(collected + lost);
    }
   
}
