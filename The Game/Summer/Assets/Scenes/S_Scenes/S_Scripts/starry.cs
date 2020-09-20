using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class starry : MonoBehaviour
{
    public GameObject stars;
    public float randomNum;
    public float yrandom;
   

     void Start()
     {
         CreateStars(20);
     }

    

    void CreateStars(int starsNum)
    {      
        for (int i = 1; i < starsNum+1; i++)
        {
            randomNum = Random.Range(-7.3f, 7.3f); 
            GameObject starsclone = Instantiate(stars, new Vector2(randomNum, i * 8), transform.rotation); 
            
        }
    }
}

