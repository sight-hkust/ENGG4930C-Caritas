using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{

    public int index;
    private static int check;


    /*  void Update()
      {
          check = Move.numberOfCorrectAns;
          if (check == 3)
          {
              SceneManager.LoadScene(levelname);
          }
      }*/
    void OnMouseDown()
    {

        SceneManager.LoadScene(index);
    }

   public void GameSelected()
    {
        SceneManager.LoadScene(index);
    }

}

