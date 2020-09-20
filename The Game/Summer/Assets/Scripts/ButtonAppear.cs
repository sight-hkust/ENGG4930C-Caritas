using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ButtonAppear : MonoBehaviour
 {
    
   public long zPosition;
    public Transform changescenebutton2;
    public UnityEngine.Video.VideoClip gamestart;
    public static string buttoncreated = "f";

void start()
    {
        var videoPlayer = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();

        videoPlayer.clip = gamestart;
        videoPlayer.playOnAwake = true;
    } 

void Start()
    {
        // Will attach a VideoPlayer to the main camera.
        //GameObject camera = GameObject.Find("Main Camera");

        // VideoPlayer automatically targets the camera backplane when it is added
        // to a camera object, no need to change videoPlayer.targetCamera.
       // var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        // Play on awake defaults to true. Set it to false to avoid the url set
        // below to auto-start playback since we're in Start().
        //videoPlayer.playOnAwake = false;

        // By default, VideoPlayers added to a camera will use the far plane.
        // Let's target the near plane instead.
        //videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

        // Set the video to play. URL supports local absolute or relative paths.
        // Here, using absolute.
        //videoPlayer.clip = gamestart;


        // Start playback. This means the VideoPlayer may have to prepare (reserve
        // resources, pre-load a few frames, etc.). To better control the delays
        // associated with this preparation one can use videoPlayer.Prepare() along with
        // its prepareCompleted event.
        //videoPlayer.Play();
    }

    void Update()
    {
        var vp = GetComponent<UnityEngine.Video.VideoPlayer>();


        if (vp.isPlaying)
        { vp.Play();  }

        else if (buttoncreated == "f" && Time.frameCount >=50)
        {
            Instantiate(changescenebutton2, new Vector3(14, -7, 1), changescenebutton2.rotation);
            buttoncreated = "t";
        }

    }
}

