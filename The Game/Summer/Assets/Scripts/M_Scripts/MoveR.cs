using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MoveR : MonoBehaviour
{
    public string pieceStatus = "idle";
    public float dirX, dirY = 0f;
    public float speed = 10f;
    public float movement = 0f;
    public Rigidbody2D rigidBody;
    //public KeyCode select;
    // public string checkPlacement = "";
    public Transform edgeParticles;
    public static string checkanswer = "n";
    public Transform Celebrate;
    public static int numberOfCorrectAns = 0;
    public Transform octopus;
    public Transform pepper;
    public Transform WellDone;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float xPosition = gameObject.transform.position.x;
        float yPosition = gameObject.transform.position.y;

        xPosition = Mathf.Clamp(gameObject.transform.position.x, 0, 104.5f);
        yPosition = Mathf.Clamp(gameObject.transform.position.y, -56, 56);

        Vector2 clampedVector = new Vector2(xPosition, yPosition);

        gameObject.transform.position = clampedVector;
    }

    void OnTriggerStay2D(Collider2D other)
    {
       

        if (other.gameObject.name == gameObject.name) //&& (checkPlacement == "y"))
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().sortingOrder = 1;
            transform.position = other.gameObject.transform.position;
            pieceStatus = "locked";
            rigidBody.velocity = new Vector2(0, 0);
            Instantiate(edgeParticles, new Vector2(66f + numberOfCorrectAns * 15, 50.6f), edgeParticles.rotation);
            Instantiate(Celebrate, other.gameObject.transform.position, Celebrate.rotation);
            //checkPlacement = "n";
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            checkanswer = "y";
            numberOfCorrectAns++;
            FindObjectOfType<AudioManager>().Play("Correct");
            Cursor.deselect();
        }

        if (numberOfCorrectAns == 3)
        {
            Invoke("Octopus", 3f);
            Invoke("Pepper", 30f);
        }

        if ((numberOfCorrectAns == 3) && (MoveLkeys.numberOfCorrectAns == 3))
        {
            Invoke("DelayedAction", 3f);
        }

        var questions = GameObject.FindGameObjectsWithTag("question");

        if (other.gameObject.name != gameObject.name && other.gameObject.name != "CursorR" ) //&&other.gameObject != questions)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        }
        
    }

    void Octopus()
    {
        Instantiate(octopus);
        FindObjectOfType<AudioManager>().Play("HalfOctopus");
    }

    void Pepper()
    {
        if ((numberOfCorrectAns == 3) && (MoveLkeys.numberOfCorrectAns < 3))
        {
            Instantiate(pepper);
        }
    }

    void DelayedAction()
    {
        numberOfCorrectAns = 0;
        MoveLkeys.numberOfCorrectAns = 0;
        Instantiate(WellDone);
    }

   
  
}
