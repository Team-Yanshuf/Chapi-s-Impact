using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    WeaponManager weaponM;


    [Header("Hit sfx")]
    [FMODUnity.EventRef] [SerializeField] string Shit;
    [Range(0f, 10f)] [SerializeField] float hitVolume;
    FMOD.Studio.EventInstance hit;

    bool ready;

	private void Start()
	{
        initSelf();
	}
	public void initSelf()
	{
        weaponM = GetComponent<WeaponManager>();

      //  hit = FMODUnity.RuntimeManager.CreateInstance(Shit);
        //setVolumes();



        //ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
		{
            playHit();
		}
    }

    void setVolumes()
	{
        hit.setVolume(hitVolume);
    }
    void playHit()
	{
        if (weaponM.isAttacking())
		{
           
            if (weaponM.getWeaponInfo().collisionI.hit)
            {
                //print("Hit played");
                hit.setParameterByName("Hit object", 1);

            }
            else
			{
                hit.setParameterByName("Hit object", 0);
			}
            hit.start();

        }            
 
	}
}
