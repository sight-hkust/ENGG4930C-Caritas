using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public float dirX, dirY = 0f;
    public float speed = 10f;
    public float movement = 0f;
    public Transform edgeParticles;
    public Rigidbody2D rigidBody;
    public string Gotcha;
    public string pieceStatus = "idle";
    private static bool selected = false;
    private static Rigidbody2D selectedObject;
    public SpriteRenderer idleCursor;
    public Sprite newCursor;
    public Sprite backtoOG;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        pieceStatus = "idle";
        idleCursor = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void Update()
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

        { rigidBody.velocity = new Vector2(dirX * speed, dirY * speed); }

        if (selected == true)
        {
            selectedObject.velocity = new Vector2(dirX * speed, dirY * speed);
        }
        float xPosition = gameObject.transform.position.x;
        float yPosition = gameObject.transform.position.y;

        xPosition = Mathf.Clamp(gameObject.transform.position.x, 0, 110);
        yPosition = Mathf.Clamp(gameObject.transform.position.y, -60, 60);

        Vector2 clampedVector = new Vector2(xPosition, yPosition);

        gameObject.transform.position = clampedVector;
        if (selectedObject == null)
        { idleCursor.sprite = backtoOG; }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        //other.gameObject.transform.localScale += new Vector3 (1, 1, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (selected == false)
            {
                ChangeSprite();
                selected = true;
                selectedObject = other.attachedRigidbody;
            }
        }
        if (other.gameObject.tag == "rotate" && Input.GetKeyDown(KeyCode.R))
        {
            ChangeSprite();
            if (!GameManage.youWin || !GameManage.youWin2)
            { other.transform.Rotate(0, 0, 90f); }
        }
    }
    void ChangeSprite()
    { idleCursor.sprite = newCursor; }

    public static void deselect()
    {
        selected = false;
        selectedObject = null;
    }

}




