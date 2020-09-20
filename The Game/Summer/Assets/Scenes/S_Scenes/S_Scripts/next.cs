using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next : MonoBehaviour
{
    public Sprite[] Characters;
    public SpriteRenderer go;
    public static int change =1;
    public GameObject choose;
    void Start()
    {
        go = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        choose = GameObject.FindWithTag("Finish");
        choose.SetActive(false);
    }

    void OnMouseDown()
    {
        change++;
        if (change == 3)
        { change = 1; }
        go.sprite = Characters[change-1];
        choose.SetActive(true);
    }
}
