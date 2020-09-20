using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MoveLkeys : MonoBehaviour
{
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

        xPosition = Mathf.Clamp(gameObject.transform.position.x, -104.5f, 0f);
        yPosition = Mathf.Clamp(gameObject.transform.position.y, -56, 56);

        Vector2 clampedVector = new Vector2(xPosition, yPosition);

        gameObject.transform.position = clampedVector;
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if ((other.gameObject.name == gameObject.name)) //&& (checkPlacement == "y"))
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().sortingOrder = 1;
            transform.position = other.gameObject.transform.position;
            
            
            rigidBody.velocity = new Vector2(0, 0);
            Instantiate(edgeParticles, new Vector2(-50f + numberOfCorrectAns * 13, 50.6f), edgeParticles.rotation);
            Instantiate(Celebrate, other.gameObject.transform.position, Celebrate.rotation);

            //checkPlacement = "n";
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            checkanswer = "y";
            numberOfCorrectAns++;
            //FindObjectOfType<AudioManager>().Stop("Wrong");
            FindObjectOfType<AudioManager>().Play("Correct");
            CursorL.deselect();
        }

        if (numberOfCorrectAns == 3)
        {

            Invoke("Octopus", 3f);
            Invoke("Pepper", 30f);

        }

        if ((numberOfCorrectAns == 3) && (MoveR.numberOfCorrectAns == 3))
        {
          Invoke("DelayedAction", 3f);
        }

        if (other.gameObject.name != gameObject.name && other.gameObject.name != "CursorL")// && (checkPlacement == "y"))
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            //FindObjectOfType<AudioManager>().Play("Wrong");
            // checkPlacement = "n";
        }
    }

    void Octopus()
    {
        Instantiate(octopus);
        FindObjectOfType<AudioManager>().Play("HalfOctopus");
    }

    void Pepper()
    {
        if ((numberOfCorrectAns == 3) && (MoveR.numberOfCorrectAns < 3))
        {
            Instantiate(pepper);
        }

    }

    void DelayedAction()
    {
        numberOfCorrectAns = 0;
        MoveR.numberOfCorrectAns = 0;
        Instantiate(WellDone);
    }
  
}