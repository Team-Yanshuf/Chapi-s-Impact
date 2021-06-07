using UnityEngine;

public class TrashcanCollision : MonoBehaviour, IVulnrable
{
    Trashcan trashM;
    bool hurt;
    bool grounded;

    bool ready;
    public bool isGrounded()
    {
        if(grounded)
		{
            grounded = false;
            return true;
		}
        return false;
    }

    public void initSelf()
	{
        hurt = false;
        trashM = GetComponent<Trashcan>();
        ready = true;
    }

    public void takeDamage(Vector3 pushback, float damage = 0)
    {
        trashM.takeDamage(damage);
        trashM.push(pushback);
        hurt = true;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (ready)
		{
            if (collision.gameObject.CompareTag("Ground"))
            {
                grounded = true;
                trashM.invokeLandEvent();
            }

            else if (collision.gameObject.CompareTag("Player"))
            {
                IVulnrable player = collision.gameObject.GetComponent<IVulnrable>();
                player.takeDamage(Vector3.zero, 10);
            }
        }
      
    }
}
