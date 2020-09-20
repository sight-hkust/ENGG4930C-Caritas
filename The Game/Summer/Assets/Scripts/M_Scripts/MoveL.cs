using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System;

public class MoveL : MonoBehaviour
{
    public string pieceStatus = "idle";
    public float dirX, dirY = 0f;
    public float speed = 5f;
    public float movement = 0f;
    public Rigidbody2D rigidBody;
    //public KeyCode select;
    // public string checkPlacement = "";
    public Transform edgeParticles;
    public static string checkanswer = "n";
    public Transform Celebrate;
    public static int numberOfCorrectAns = 0;
    public Transform octopus;
    SerialPort sp = new SerialPort("/dev/cu.usbmodem14101", 9600);
    Thread joystickProcessingThread;
    int currentDirection = 0;
    public Transform pepper;
    public Transform WellDone;

    void processMovementSignal()
    {
        while (joystickProcessingThread.IsAlive && sp.IsOpen)
        {
            currentDirection = sp.ReadByte();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    private void OnDisable()
    {
        //if (sp.IsOpen) { sp.Close(); }

        //joystickProcessingThread.Abort();
    }
    void Update()
    {
        if (pieceStatus == "picked up")
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

            rigidBody.velocity = new Vector2(dirX * speed, dirY * speed);
        }

        //if (Input.GetKeyDown(select) && pieceStatus == "picked up")
        {
            //    checkPlacement = "y";
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {

        if ((other.gameObject.name == gameObject.name)) //&& (checkPlacement == "y"))
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().sortingOrder = 1;
            transform.position = other.gameObject.transform.position;
            pieceStatus = "locked";
            rigidBody.velocity = new Vector2(0, 0);
            Instantiate(edgeParticles, new Vector2(10.5f + numberOfCorrectAns * 13, 50f), edgeParticles.rotation);
            Instantiate(Celebrate, other.gameObject.transform.position, Celebrate.rotation);

            //checkPlacement = "n";
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            checkanswer = "y";
            numberOfCorrectAns++;
            //FindObjectOfType<AudioManager>().Stop("Wrong");
            FindObjectOfType<AudioManager>().Play("Correct");

        }

        if (numberOfCorrectAns == 3)
        {

            Invoke("Octopus", 3f);
            Invoke("Pepper", 30f);

        }

        if ((numberOfCorrectAns == 3) && (MoveR.numberOfCorrectAns == 3))
        {
            /*numberOfCorrectAns = 0;
             MoveR.numberOfCorrectAns = 0;*/
            Invoke("DelayedAction", 6f);
        }



        if ((other.gameObject.name != gameObject.name))// && (checkPlacement == "y"))
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
    void OnMouseDown()

    {
        pieceStatus = "picked up";
        gameObject.transform.position = new Vector2(transform.position.x + 35f, transform.position.y);
        // checkPlacement = "n";
        GetComponent<Renderer>().sortingOrder = 10;
    }
}