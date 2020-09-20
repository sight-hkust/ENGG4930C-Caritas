using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clouds : MonoBehaviour
{
   public GameObject addcloud;
    public GameObject cloudy;
    void Start()
    {
        Createclouds(25);
    }
    void Createclouds( int no)
    { for (int i=1; i<no;i++)
        {
           cloudy = Instantiate(addcloud);
            cloudy.transform.position = new Vector2(transform.position.x, 10f*i);
        }
    }
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.025f);
       // if (star.collected + star.lost == 20)
        //{ Destroy(cloudy); }
    }
    
}
