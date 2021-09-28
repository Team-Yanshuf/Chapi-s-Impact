using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAudio : MonoBehaviour
{
    Wheel wheelM;

    [Header("Startup & Dash SFX")]
    [FMODUnity.EventRef] [SerializeField] string SsoundEvent;
    [Range(0f, 10f)] [SerializeField] float volume;
    FMOD.Studio.EventInstance soundEvent;
    public void InitSelf()
	{
        wheelM = GetComponent<Wheel>();
        //soundEvent = FMODUnity.RuntimeManager.CreateInstance(SsoundEvent);
        //soundEvent.setVolume(volume);
 
        wheelM.GetWheelEvents().wheelStarted.AddListener(PlaySound);


    }

    
    public void PlaySound()
	{
        //print("Attempting to play music!");
  //      if (!soundEvent.isPlaying())
		//{
  //          soundEvent.start();
		//}
	}
}
