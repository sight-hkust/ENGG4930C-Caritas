using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class scoreStats : MonoBehaviour
{
    public GameObject score;
    
    void Start()
    {
        GenerateScore(star.collected);
    }

   
    void GenerateScore(int stars)
    {

        for (int i = 0; i < stars + 1; i++)
        { if (i < 5)
            { GameObject clone = Instantiate(score, new Vector2(-6 + 3 * i, 0.5f), transform.rotation); }
            if (i>5 && i<11 )
            { GameObject clone2 = Instantiate(score, new Vector2(-6 + 3 * (i-6), -1f), transform.rotation); }
            if (i > 10 && i < 16)
            { GameObject clone2 = Instantiate(score, new Vector2(-6 + 3 * (i - 11), -2.5f), transform.rotation); }
            if (i > 15 && i < 21)
            { GameObject clone2 = Instantiate(score, new Vector2(-6 + 3 * (i - 16), -4f), transform.rotation); }
        }
      }
    void Update()
    {
        star.collected = 0;
        star.lost = 0;
    }


}

    

