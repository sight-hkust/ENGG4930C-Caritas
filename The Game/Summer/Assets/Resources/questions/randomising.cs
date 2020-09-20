using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomising : MonoBehaviour
{
    public int randomNum;
    public int lastnum;
    // Start is called before the first frame update
    void Awake()
    {
        randomNum = Random.Range(1, 7);
        if (lastnum== randomNum)
        { randomNum = Random.Range(1, 7); }
        lastnum = randomNum;
    }
    void Start()
    {
        
        var Object = GetComponent<SpriteRenderer>();

        for (int i = 1; i < 7; i++)
        {
            if (Object.name == "A" + i)
            {
                Object.sprite = Resources.Load<Sprite>("questions/pic" + randomNum);
                GameObject A1 = GameObject.FindWithTag("answer" + i);
                A1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("answers/pic" + randomNum);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {}
}
