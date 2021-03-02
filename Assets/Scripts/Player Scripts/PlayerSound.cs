using UnityEngine;

public class PlayerSound : MonoBehaviour

{
    /*
     * Sounds exist for:
     * footsteps
     * dash
     * shooting
     * taking damage (hurt)
     * hitting
     * dying
     * 
     * 
    */

    Player playerM;

    
    [SerializeField]  FMODUnity.StudioEventEmitter footsteps;
    [SerializeField]  FMODUnity.StudioEventEmitter dash;
    [SerializeField]  FMODUnity.StudioEventEmitter shoot;
    [SerializeField]  FMODUnity.StudioEventEmitter hurt;
    [SerializeField] FMODUnity.StudioEventEmitter hit;
    [SerializeField] FMODUnity.StudioEventEmitter death;
    
    void Start()
    {
        GameManagerEvents.chapiDied?.AddListener(playDie);
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
        if (!footsteps)
            return;

       if  (playerM.isMoving())
        {
            if (!footsteps.IsPlaying())
                footsteps.Play();
        }
    }

    void playDash()
    {
        if (!dash)
            return;

        if (playerM.isDashing()  && !dash.IsPlaying())
        {
            dash.Play();
        }
    }
    void playCollect()
    {             
    }

    void playShooting()
    {
        if (!shoot)
            return;

        if (playerM.isShooting() && !shoot.IsPlaying())
        {
            shoot.Play();
        }
    }

    void playHurt()
	{
        if (playerM.isHurt())
            hurt?.Play();
	}

    void playDie()
	{
        death?.Play();
	}
}
