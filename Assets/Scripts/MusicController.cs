using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public FMODUnity.EventReference musicEventRef;
    private string music;
    FMOD.Studio.EventInstance musicEvent;

    // Start is called before the first frame update
    void Start()
    {
        music = "event:/Main_Theme";
        musicEvent = FMODUnity.RuntimeManager.CreateInstance(music);
        musicEvent.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string musicEventGo()
    {
        return "event:/Go";
    }

    public string musicEventStop()
    {
        
        return "event:/Stop";
    }
}
