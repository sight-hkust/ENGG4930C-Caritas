using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move2 : MonoBehaviour
{
    //public string pieceStatus = "idle";
    public float dirX, dirY = 0f;
    public float speed = 10f;
    public float movement = 0f;
    public Rigidbody2D rigidBody;
    public KeyCode select;
    // public string checkPlacement = "";
    public Transform edgeParticles;
    public static string checkanswer = "n";
    public static int numberOfCorrectAns = 0;
    public string levelname;
    public float delayTime = 0.5f;
    public Transform Celebrate;
    public string Done = "passed";

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        { dirX = 1f; }
        else
        {
            if (Input.GetKeyUp(KeyCode.RightArrow))
            { dirX = 0f; }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        { dirX = -1f; }
        else
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            { dirX = 0f; }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        { dirY = 1f; }
        else
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            { dirY = 0f; }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        { dirY = -1f; }
        else
        {
            if (Input.GetKeyUp(KeyCode.DownArrow))
            { dirY = 0f; }
        }

        if (Done == "passed")
        { rigidBody.velocity = new Vector2(dirX * speed, dirY * speed); }
    }

            /*if (pieceStatus == "picked up")
            {
                movement = Input.GetAxis("Horizontal");
                rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
                movement = Input.GetAxis("Vertical");
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, movement * speed);
            }*/

            /* if (Input.GetKeyDown(select) && pieceStatus== "picked up")
             {
                 checkPlacement = "y";
             }*/
        

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.name == gameObject.name)
            {
                transform.position = other.gameObject.transform.position;
                rigidBody.velocity = new Vector2(0, 0);
                Instantiate(edgeParticles, new Vector2(76f, 0), edgeParticles.rotation);
                Instantiate(Celebrate, other.gameObject.transform.position, Celebrate.rotation);
                other.GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<Renderer>().sortingOrder = 1;
                Done = "over";
            }
        }
}


 


   /* void OnMouseDown()

    {

        pieceStatus = "picked up";
        gameObject.transform.position = new Vector2(transform.position.x + 10, transform.position.y);
        //   checkPlacement = "n";
        GetComponent<Renderer>().sortingOrder = 10;
    }*/
