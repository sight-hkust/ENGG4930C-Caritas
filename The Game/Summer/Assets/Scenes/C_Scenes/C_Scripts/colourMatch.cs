 using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class colourMatch : MonoBehaviour
{
    public float dirX, dirY = 0f;
    public float speed = 40f;
    public Rigidbody2D rigidBody;
 
    // Start is called before the first frame update

    void Start()
    {
  
        rigidBody = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == gameObject.name && other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            Destroy(gameObject);
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            PaintbrushcursorR.deselect();

        }

        if (other.gameObject.name == gameObject.name && other.gameObject.tag == "PlayerL")
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            Destroy(gameObject);
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            Paintbrushcursor.deselect();

        }


    }
}
