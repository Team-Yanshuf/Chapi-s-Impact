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


            Vector3 direction = (transform.position - collision.transform.position).normalized;
            //Vector3 pushback = new Vector3(-direction, 0, 0);
            
            enemy?.takeDamage(-direction * 20, 25);
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
           // print(hit);
            hit = false;
            return true;
		}
        else
		{
           // print("False reached");
            return false;
        }

	}

    public WeaponCollisionInfo getWeaponCollisionInfo()
	{
        //print(getHit());
        //print(GameObject.FindObjectsOfType<WeaponCollision>()[1]);
        return new WeaponCollisionInfo(getHit());
	}
}

