using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour, IVulnrable
{

    Player playerM;
    bool collecting;
    bool hurt;
    private void Start()
    {
        playerM = GetComponent<Player>();
    }


    public bool isCollecting()
    {
        bool temp = collecting;
        collecting = false;
        return temp;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
            collecting = true;
    }

    public void takeDamage(Vector3 pushback, float damage = 0)
    {
        hurt = true;
        playerM.takeDamage(damage);
    }

    public bool isHurt()
	{
        if (hurt)
		{
            hurt = false;
            return true;
		}
        return false;
	}
}
