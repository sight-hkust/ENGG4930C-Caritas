using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{public Transform[] pipes;
    public static bool youWin;
    public static bool youWin2;
    // public GameObject wintext;
    public Transform ferret;
    public Transform cheese;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        youWin = false;
        //wintext.SetActive(false);
        youWin2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pipes[0].rotation.z == 0 &&
            pipes[1].rotation.z == 0 &&
            pipes[2].rotation.z == 0 &&
            pipes[3].rotation.z == 0 &&
            pipes[4].rotation.z == 0)
           
        { Instantiate(ferret, ferret.transform.position, ferret.rotation);
            youWin = true;
        }
        
        if (pipes[5].rotation.z == 0 &&
            pipes[6].rotation.z == 0 &&
            pipes[7].rotation.z == 0 &&
            pipes[8].rotation.z == 0 &&
            pipes[9].rotation.z == 0)
        { Instantiate(cheese, cheese.transform.position, cheese.rotation);
            youWin2 = true;
        }

        if(youWin==true && youWin2==true )
        { Invoke("SceneChange", 2f); }
    }

    void SceneChange()
    { SceneManager.LoadScene(index); }
   
}
