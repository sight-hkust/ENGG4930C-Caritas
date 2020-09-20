using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Superman : MonoBehaviour
{
    public int dirX;
    public int speed = 10;
    public static Vector2 Objectpos;
    public Sprite[] characterflying;
    public Animator supermanflinch;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        { dirX = -1; }
        if (Input.GetKeyUp(KeyCode.A))
        { dirX = 0; }
        if (Input.GetKeyDown(KeyCode.D))
        { dirX = 1; }
        if (Input.GetKeyUp(KeyCode.D))
        { dirX = 0; }
        GetComponent<Rigidbody2D>().velocity = new Vector2(dirX * speed, transform.position.y * 0);// + 1f);

        float xPosition = gameObject.transform.position.x;
        xPosition = Mathf.Clamp(gameObject.transform.position.x, -7.3f, 7.3f);
        Vector2 clampedVector = new Vector2(xPosition, transform.position.y);
        gameObject.transform.position = clampedVector;

        if (star.lost + star.collected == 20 || Eachmonster.ouch==3)
        { Destroy(gameObject); }

        GetComponent<SpriteRenderer>().sprite = characterflying[next.change - 1];
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            supermanflinch.SetBool("Monsterhit", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Respawn")
        { supermanflinch.SetBool("Monsterhit", false); }
    }
}
