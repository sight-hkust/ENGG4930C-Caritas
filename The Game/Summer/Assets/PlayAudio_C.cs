using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio_C : MonoBehaviour
{
    public string audioname;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play(audioname);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
