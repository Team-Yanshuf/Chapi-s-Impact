using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{

    Player playerM;
    List<PowerupInfo> powerups;
	SpriteRenderer renderer;
    PlayerMovement movement;
    PlayerAttacking attacking;
    PlayerHealth health;
    Transform weaponTransform;

    public void initSelf()
	{
        playerM = GetComponent<Player>();
        powerups = new List<PowerupInfo>();
        renderer = GetComponent<SpriteRenderer>();
        movement = GetComponent<PlayerMovement>();
        attacking = GetComponent<PlayerAttacking>();
        health = GetComponent<PlayerHealth>();
        weaponTransform = GameObject.Find("Chapi'sWeapon").transform;
    }
    public void addNewPowerup(PowerupInfo powerup)
	{

        applyPowerup(powerup);
        powerups.Add(powerup);
	}

    void applyPowerup(PowerupInfo powerup)
	{
        switch(powerup.type)
		{
            case "AttrubiteModifier":
				{

                    break;
				}
		}

        switch(powerup.modifier)
		{
            case "EnlargeWeapon":
				{
                    //weaponTransform.localScale *= 2;
                    //weaponTransform.position += new Vector3(0, 1, 0);
                    StartCoroutine(enlarge(2));
                    IEnumerator enlarge(int scale)
					{
                        Vector3 target = weaponTransform.localScale * scale;
                        for(int i=0; i<50; i++)
						{
                            weaponTransform.position += new Vector3(0, 0.02f, 0);
                            weaponTransform.localScale=Vector3.Lerp(weaponTransform.localScale, target, 0.02f * i);
                            yield return null;
						}
					}
                    break;
				}

			case "SpeedUp":
				{
                    movement.setSpeed(movement.getSpeed()+0.5f);
                    break;
				}
		}
	}
}
