using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public class matchdestroy : MonoBehaviour
{
    private bool Rcompletion = false;
    private bool Lcompletion = false;
    //public string GameType;
    //private string AudioTrack;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(gameObject.name== other.gameObject.name && gameObject.tag=="PlayerL")
        { Destroy(other.gameObject);
            Destroy(gameObject);
            Paintbrushcursor.deselect();
            //LnumberOfCorrectAns++;
        }
        if (gameObject.name == other.gameObject.name && gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            PaintbrushcursorR.deselect();
            //RnumberOfCorrectAns++;

           // Rcompletion = true;
        }

        /*if (LnumberOfCorrectAns == 2)
        { Lcompletion = true; }

        if (RnumberOfCorrectAns == 2)
        { Rcompletion = true; }

        if ((Rcompletion = true) && (Lcompletion = true))
        {
            FindObjectOfType<AudioManager>().Play("FlowersBloom");
        }*/
    }
}
