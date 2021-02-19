using UnityEditor;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
	Timer timer;
	[SerializeField] Projectile projectile;
	[SerializeField] float projectileSpeed;

	bool shooting=false;
	Player playerM;
	IWeapon staff;

	void Start()
	{
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

	void melee()
	{
		load();
	   if (Input.GetKeyDown(KeyCode.Space))
		{
			staff.attack();
		}
	}

	void throwProjectile()
	{
		shooting = true;
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

		 else return false;



    }

	void load()
	{
		PrefabUtility.InstantiatePrefab(timer);
	}

	


}
