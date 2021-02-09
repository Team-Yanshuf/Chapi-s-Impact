using UnityEngine;

public class PlayerSound : MonoBehaviour

{
    Player playerM;

    [SerializeField] AudioSource footSteps;
    [SerializeField] AudioSource hurt;
    [SerializeField] AudioSource attack;
    [SerializeField] AudioSource collect;

    private FMOD.Studio.EventInstance instance;

    [FMODUnity.EventRef]
    public string fmodEvent;

    [SerializeField]
    [Range(0f, 1f)]
    private float Walking;

    

    // Start is called before the first frame update
    void Start()
    {
      //  instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);

        playerM = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
       // playFootSetps();
    }

    void playFootSetps()
    {
       // bool isPlaying = instance.getPlaybackState(studio.PLAYBACK_STATE.FMOD_STUDIO_PLAYBACK_STOPPED)



       // if  (playerM.isMoving())
        {
            //Debug.Log("Trying to play footsteps");
           
          //  instance.start();
        }

       

    }

    void playCollect()
    {
        if (!collect)
            return;

        if (playerM.isCollecting())
            collect.Play();
            
    }
}
