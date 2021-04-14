using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanCollision : MonoBehaviour, IVulnrable
{
    Trashcan trashM;
    bool hurt;
    bool grounded;

    public bool isGrounded() => grounded;
    // Start is called before the first frame update
    void Start()
    {
        hurt = false;
        trashM = GetComponent<Trashcan>();
    }

    public void takeDamage(Vector3 pushback, float damage = 0)
    {
        trashM.takeDamage(damage);
        hurt = true;
	}

    bool isHurt()
	{
        if (hurt)
		{
            hurt = false;
            return true;
		}
        return false;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            trashM.invokeLandEvent();
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            IVulnrable player = collision.gameObject.GetComponent<IVulnrable>();
            player.takeDamage(Vector3.zero,10);
        }
    }
}
