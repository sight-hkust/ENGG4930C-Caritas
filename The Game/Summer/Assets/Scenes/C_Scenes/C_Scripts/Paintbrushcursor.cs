using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;


public class Paintbrushcursor : MonoBehaviour
{
    public float dirX, dirY = 0f;
    public float speed = 40f;
    public float movement = 0f;
    public Transform edgeParticles;
    public Rigidbody2D rigidBody;
    public string Gotcha;
    public string pieceStatus = "idle";
    public static bool selected = false;
    public static Rigidbody2D selectedObject;
    public SpriteRenderer idleCursor;
    public Sprite[] newCursors;
    public bool cursor;
    public Sprite backtoOG;



    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        pieceStatus = "idle";
        idleCursor = gameObject.GetComponent<SpriteRenderer>();
        cursor = false;

    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        { dirX = 1f; }
        else
        {
            if (Input.GetKeyUp(KeyCode.D))
            { dirX = 0f; }
        }

        if (Input.GetKeyDown(KeyCode.A))
        { dirX = -1f; }
        else
        {
            if (Input.GetKeyUp(KeyCode.A))
            { dirX = 0f; }
        }
        if (Input.GetKeyDown(KeyCode.W))
        { dirY = 1f; }
        else
        {
            if (Input.GetKeyUp(KeyCode.W))
            { dirY = 0f; }
        }
        if (Input.GetKeyDown(KeyCode.S))
        { dirY = -1f; }
        else
        {
            if (Input.GetKeyUp(KeyCode.S))
            { dirY = 0f; }
        }
        if(selected==false)
        { rigidBody.velocity = new Vector2(dirX * speed, dirY * speed); }

        if (selected == true)
        {
            selectedObject.velocity = new Vector2(dirX * speed, dirY * speed);
                rigidBody.velocity = new Vector2(dirX * speed, dirY * speed); 
        }
       /* float xPosition = gameObject.transform.position.x;
        float yPosition = gameObject.transform.position.y;

        xPosition = Mathf.Clamp(gameObject.transform.position.x, -50, 40.7f);
        yPosition = Mathf.Clamp(gameObject.transform.position.y, -56, 56);

        Vector2 clampedVector = new Vector2(xPosition, yPosition);

        gameObject.transform.position = clampedVector;*/

      if (selectedObject == null)
      { idleCursor.sprite = backtoOG;}
      
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        //other.gameObject.transform.localScale += new Vector3 (1, 1, 0);

        for (int i = 1; i < 10; i++)
        {
            if (other.gameObject.name == "A" + i && Input.GetKeyDown(KeyCode.Space) && other.gameObject.tag == "PlayerL")
            {
                idleCursor.sprite = newCursors[i - 1];
                selected = true;
                selectedObject = other.attachedRigidbody;
            }
        }
    }
  
   public static void deselect()
    {
        selected = false;
        selectedObject = null;

    }

}


