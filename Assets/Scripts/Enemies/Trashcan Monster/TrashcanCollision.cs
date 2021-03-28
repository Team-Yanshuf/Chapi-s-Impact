using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanCollision : MonoBehaviour, IVulnrable
{
    Trashcan trashM;
    bool hurt;
    float hp;
    bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        hurt = false;
        trashM = GetComponent<Trashcan>();
        hp = trashM.getMaxHP();
    }

    // Update is called once per frame
    void Update()
    {
        checkIfAlive();
    }

    void checkIfAlive()
	{
        if (hp<=0)
		{
            GameManagerEvents.onEnemyDefeated();
            trashM.die();
		}
	}

    public void takeDamage(Vector3 pushback, float damage = 0)
    {
        print("trashcan hurt" + "\t" + damage);
        hp -= damage;
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

    public bool isGrounded() => grounded;
}
