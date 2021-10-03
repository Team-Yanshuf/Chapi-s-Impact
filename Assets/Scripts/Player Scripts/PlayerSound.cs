using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    Player playerM;

    [Header("Footstep sfx")]
    [FMODUnity.EventRef] [SerializeField] string Sfootsteps;
    [Range(0f, 10f)] [SerializeField] float footstepsVolume;
    FMOD.Studio.EventInstance footsteps;

    [Header("Dash sfx")]
    [FMODUnity.EventRef] [SerializeField] string Sdash;
    [Range(0f, 10f)] [SerializeField] float dashVolume;
    FMOD.Studio.EventInstance dash;

    [Header("Shooting sfx")]
    [FMODUnity.EventRef] [SerializeField] string Sshoot;
    [Range(0f, 10f)] [SerializeField] float shootVolume;
    FMOD.Studio.EventInstance shoot;

    [Header("Hurt sfx")]
    [FMODUnity.EventRef] [SerializeField] string Shurt;
    [Range(0f, 10f)] [SerializeField] float hurtVolume;
    FMOD.Studio.EventInstance hurt;

    [Header("Hit sfx")]
    [FMODUnity.EventRef] [SerializeField] string Shit;
    [Range(0f, 10f)] [SerializeField] float hitVolume;
    FMOD.Studio.EventInstance hit;

    [Header("Death sfx")]
    [FMODUnity.EventRef] [SerializeField] string Sdeath;
    [Range(0f, 10f)] [SerializeField] float deathVolume;
    FMOD.Studio.EventInstance death;

    [Header("Aura sfx")]
    [FMODUnity.EventRef] [SerializeField] string Saura;
    [Range(0f, 10f)] [SerializeField] float auraVolume;
    FMOD.Studio.EventInstance aura;

    bool plant;
    int attackNumber;

    bool finishedInitializing = false;
    void initSelf()
	{
        footsteps = FMODUnity.RuntimeManager.CreateInstance(Sfootsteps);
		dash = FMODUnity.RuntimeManager.CreateInstance(Sdash);
		hit = FMODUnity.RuntimeManager.CreateInstance(Shit);
		aura = FMODUnity.RuntimeManager.CreateInstance(Saura);

        //shoot = FMODUnity.RuntimeManager.CreateInstance(Sshoot);
        //death = FMODUnity.RuntimeManager.CreateInstance(Sdeath);
    }

    void setVolumes()
	{
        footsteps.setVolume(footstepsVolume);
        dash.setVolume(dashVolume);
        hit.setVolume(hitVolume);
        aura.setVolume(auraVolume);
    }

    void Start()
    {
        initSelf();
        GameManagerEvents.chapiDied?.AddListener(playDie);
        playerM = GetComponent<Player>();
        attackNumber = -1;
        plant = false;
        finishedInitializing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (finishedInitializing)
		{
            playFootSetps();
            playDash();
            playShooting();
            playHurt();
            playHit();
            playAura();

            setVolumes();
        }

    }

    void playFootSetps()
    {

        if (playerM.isMoving())
		{
            if (!footsteps.isPlaying())
			{
                footsteps.start();
			}
		}
    }

    void playDash()
    {
		if (playerM.isDashing() && !dash.isPlaying())
		{
			dash.start();
		}
	}
    void playCollect()
    {             
    }

    void playShooting()
    {

		if (playerM.isShooting() && !shoot.isPlaying())
		{
			shoot.start();
		}
	}

    void playHurt()
	{
		if (playerM.isHurt())
		{
			hurt.start();
			print("player hurt is playing");
		}
	}

    void playHit()
	{
		if (playerM.isAttacking() && attackNumber != playerM.comboCount())
		{
            if (playerM.weaponM.getWeaponInfo().collisionI.hit)
			{
                hit.setParameterByName("Hit object", 1);
			}
            else
			{
                hit.setParameterByName("Hit object", 0);
			}

			hit.start();
			attackNumber = playerM.comboCount();
		}
		else if (!playerM.isAttacking())
		{
			attackNumber = -1;
		}
	}

    void playDie()
	{
        //death?.Play();
	}

    void playAura()
	{
		if (playerM.getHowManyTreesCanPlant() > 0 && !plant)
		{
			plant = true;
			aura.start();
		}

		else if (playerM.getHowManyTreesCanPlant() == 0)
			plant = false;
	}
}
