using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
	[SerializeField] Projectile projectile;
	[SerializeField] float projectileSpeed;
	bool shooting;
	bool attacking;
	Player playerM;
	IWeapon staff;

	void Start()
	{
		shooting = false;
		attacking = false;
		staff = GetComponentInChildren<Staff>();
		playerM = GetComponent<Player>();
	}

	// Update is called once per frame
	void Update()
	{
		if (playerM.meleePressed())
			melee();


		//SHOOTING IS NOT WORKING PROPERLY NOW. WILL FIX LATER.
		//if (playerM.shootingPressed())
		//shoot();

		//private void shoot()
		//{
		//	shooting = true;
		//	throwProjectile();
		//}

	}



	/********************** Handle Melee ********************/
	void melee() => staff.requestNextAttack();
	public int getComboCount() => staff.getCurrentComboHit();


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

	public bool isAttacking() => staff.isAttacking();
}