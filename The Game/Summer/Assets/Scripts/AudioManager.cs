using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;


public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    public Sounds s;
    
    
    // Start is called before the first frame update
   void Awake ()
    {
        
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.playOnAwake = false;
            s.source.volume = 0.3f; 
        }
    }

    public void Play (string name)
    {
        Sounds s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
        //s.source.enabled = true;
    }

    public void Stop (string name)
    {
        Sounds s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Stop();
       
    }


}
