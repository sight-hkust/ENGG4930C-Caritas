using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{public Transform[] pipes;
    public static bool youWin;
    public static bool youWin2;
    // public GameObject wintext;
    public GameObject ferret;
    public GameObject cheese;
    public int index;
    
    void Start()
    {
        youWin = false;
        //wintext.SetActive(false);
        youWin2 = false;
        ferret.SetActive(false);
        cheese.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pipes[0].rotation.z == 0 &&
            pipes[1].rotation.z == 0 &&
            pipes[2].rotation.z == 0 &&
            pipes[3].rotation.z == 0 &&
            pipes[4].rotation.z == 0)
           
        {
            ferret.SetActive(true);
            //Instantiate(ferret, ferret.transform.position, ferret.rotation);
            youWin = true;
        }
        
        if (pipes[5].rotation.z == 0 &&
            pipes[6].rotation.z == 0 &&
            pipes[7].rotation.z == 0 &&
            pipes[8].rotation.z == 0 &&
            pipes[9].rotation.z == 0)
        { //Instantiate(cheese, cheese.transform.position, cheese.rotation);
            youWin2 = true;
            cheese.SetActive(true);
        }

        if(youWin==true && youWin2==true )
        { Invoke("SceneChange", 1f); }
    }

    void SceneChange()
    { SceneManager.LoadScene(index); }
   
}
