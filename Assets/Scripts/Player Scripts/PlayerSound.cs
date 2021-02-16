using UnityEngine;

public class PlayerSound : MonoBehaviour

{
    Player playerM;

    
    [SerializeField]  FMODUnity.StudioEventEmitter footstepsEmmiter;
    [SerializeField]  FMODUnity.StudioEventEmitter dash;
    [SerializeField]  FMODUnity.StudioEventEmitter shoot;
    [SerializeField]  FMODUnity.StudioEventEmitter hurt;
    //private FMOD.Studio.EventInstance instance;





    // Start is called before the first frame update
    void Start()
    {

        playerM = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
             playFootSetps();
        playDash();
        playShooting();
    }

    void playFootSetps()
    {
       // bool isPlaying = instance.getPlaybackState(studio.PLAYBACK_STATE.FMOD_STUDIO_PLAYBACK_STOPPED)



       if  (playerM.isMoving())
        {
            if (!footstepsEmmiter.IsPlaying())
                footstepsEmmiter.Play();
           // instance.setParameterByName("Walking", 1);
            //Debug.Log("Trying to play footsteps");
           
           // instance.start();
        }

       

    }

    void playDash()
    {
        if (playerM.isDashing() && !dash.IsPlaying())
        {
            dash.Play();
        }
    }
    void playCollect()
    {
        
            
    }

    void playShooting()
    {
        if (playerM.isShooting() && !shoot.IsPlaying())
        {
            shoot.Play();
        }


    }
}
