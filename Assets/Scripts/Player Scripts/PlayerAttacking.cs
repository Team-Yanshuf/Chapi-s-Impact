using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
	[SerializeField] Projectile projectile;
	[SerializeField] float projectileSpeed;

	Player playerM;
	CapsuleCollider hitbox;
	IWeapon staff;
	bool isAttacking;

	void Start()
	{
		staff = GetComponentInChildren<Staff>();
		isAttacking = false;
		hitbox=GetComponentInChildren<CapsuleCollider>();
		playerM = GetComponent<Player>();
	}

	// Update is called once per frame
	void Update()
	{
		melee(); 
		
		if (Input.GetMouseButtonDown(0))
		{
			throwProjectile();
		}
	}

	void melee()
	{
	   if (Input.GetKeyDown(KeyCode.Space))
		{
			staff.attack();
		}
	}

	void throwProjectile()
	{
		Vector3 direction = playerM.getDirectionToMouseNormalized();
		Projectile proj = Instantiate<Projectile>(projectile, transform.position, Quaternion.identity);

		proj.transform.LookAt(playerM.getDirectionToMouseNormalized()); ;
	}




}
