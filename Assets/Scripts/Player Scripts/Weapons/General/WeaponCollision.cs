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

    bool hit;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy") && !collision.isTrigger)
        {
            IVulnrable enemy = collision.GetComponent<IVulnrable>();
            Vector3 pushback = new Vector3(transform.localScale.x, 0, 0);
            enemy?.takeDamage(pushback * 5, 25);
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

