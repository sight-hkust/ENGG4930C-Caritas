using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomisefruits : MonoBehaviour
{
    public int randomNum;
    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(1, 8);
        var Object = GetComponent<SpriteRenderer>();

        for (int i = 1; i < 8; i++)
        {
            if (Object.name == "A" + i)
            {
                Object.sprite = Resources.Load<Sprite>("2questions/pic" + randomNum);
                GameObject A1 = GameObject.FindWithTag("answer" + i);
                A1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("2answers/pic" + randomNum);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
