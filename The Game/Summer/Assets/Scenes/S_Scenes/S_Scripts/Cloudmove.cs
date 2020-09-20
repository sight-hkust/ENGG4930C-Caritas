using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloudmove : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.025f);
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
        if (star.collected + star.lost == 20)
        { transform.position = new Vector2(0.39f, -1.725f); }
    }

}
