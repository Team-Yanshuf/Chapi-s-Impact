using FMOD.Studio;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
	[SerializeField] Projectile projectile;
	[SerializeField] float projectileSpeed;
	bool shooting;
	Player playerM;
	IWeapon staff;

	void Start()
	{
		shooting = false;
		staff = GetComponentInChildren<Staff>();
		playerM = GetComponent<Player>();
	}

	// Update is called once per frame
	void Update()
	{
		melee(); 
		
		if (Input.GetMouseButtonDown(0))
		{
			shooting = true;
			throwProjectile();
		}
	}

	/********************** Handle Melee ********************/


	void melee()
	{
	   if (Input.GetKeyDown(KeyCode.Space))
		{
			staff.attack();
		}
	}

	public int getComboCount()
	{
		return staff.getCurrentComboHit();
	}

	/******************* Handle Long Range *******************/
	void throwProjectile()
	{
		Vector3 direction = playerM.getDirectionToMouseNormalized();
		float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
		Projectile proj = Instantiate(projectile, transform.position, Quaternion.identity);
 
		proj?.fireWithRotation(Quaternion.AngleAxis(angle,Vector3.forward),direction.normalized);
	}

	public bool isShooting()
	{
		if (shooting)
		{
			shooting = false;
			return true;
		}
		return false;
	}



}
