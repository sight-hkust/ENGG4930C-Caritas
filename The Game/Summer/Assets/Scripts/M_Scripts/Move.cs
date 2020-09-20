using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    //  public string pieceStatus = "idle";
    public float dirX, dirY = 0f;
    public float speed = 10f;
    public float movement = 0f;
    public Rigidbody2D rigidBody;
    public KeyCode select;
    // public string checkPlacement = "";
    public Transform edgeParticles;
    public Transform Celebrate;
    public static string checkanswer = "n";
    public static int numberOfCorrectAns = 0;
    int currentDirection = 0;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDirection == 3 || Input.GetKeyDown(KeyCode.W
                ))
        { dirX = 1f; }
        else
        {
            if (currentDirection == 0)
            { dirX = 0f; }
        }

        if (currentDirection == 4 || Input.GetKeyDown(KeyCode.A
            ))

        { dirX = -1f; }
        else
        {
            if (currentDirection == 0)
            { dirX = 0f; }
        }
        if (currentDirection == 5 || Input.GetKeyDown(KeyCode.D
            ))
        { dirY = 1f; }
        else
        {
            if (currentDirection == 0)
            { dirY = 0f; }
        }
        if (currentDirection == 6 || Input.GetKeyDown(KeyCode.S
            ))
        { dirY = -1f; }
        else
        {
            if (currentDirection == 0)
            { dirY = 0f; }
        }


        { rigidBody.velocity = new Vector2(dirX * speed, dirY * speed); }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.name == gameObject.name))
        {
            transform.position = other.gameObject.transform.position;
            rigidBody.velocity = new Vector2(0, 0);
            Instantiate(edgeParticles, new Vector2(-9f, 0), edgeParticles.rotation);
            Instantiate(Celebrate, other.gameObject.transform.position, Celebrate.rotation);
        }
    }
}
           
        

