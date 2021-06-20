using UnityEngine;

public struct WeaponCollisionInfo
{
    public bool hit { get; }

    public WeaponCollisionInfo(bool hit)
	{
        this.hit = hit;
	}
}

public class WeaponCollision : MonoBehaviour
{
    WeaponManager manager;

	private void Start()
	{
        manager = GetComponent<WeaponManager>();
	}
	bool hit;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy") && !collision.isTrigger)
        {
            IVulnrable enemy = collision.GetComponent<IVulnrable>();


            Vector3 pushbackForce = (collision.transform.position - transform.position).normalized;
            
            enemy?.takeDamage(pushbackForce * 5, 25);
            Camera.main.GetComponent<CameraFollowPlayer>().shake();
            hit = true;
            print(hit);
        }

		if (collision.CompareTag("ItemTent"))
		{
			IVulnrable tent = collision.GetComponent<IVulnrable>();
			tent.takeDamage(Vector3.zero, 0);
            Camera.main.GetComponent<CameraFollowPlayer>().shake();
            hit = true;
        }
	}

    bool getHit()
	{
        if (hit)
		{
            hit = false;
            return true;
		}
        else
		{
            return false;
        }

	}

    public WeaponCollisionInfo getWeaponCollisionInfo()
	{
        return new WeaponCollisionInfo(getHit());
	}
}

