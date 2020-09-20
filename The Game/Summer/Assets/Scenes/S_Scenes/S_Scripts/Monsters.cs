using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public GameObject monsters;
    public float randomNum;
    void Start()
    {
        Createmonsters(5);
    }

    void Createmonsters(int no)
    {
        for (int i = 1; i < no + 1; i++)
        {
            randomNum = Random.Range(-7.3f, 7.3f);
            GameObject monster = Instantiate(monsters, new Vector2(randomNum, i * 40), transform.rotation);
        }
    }

  

}
