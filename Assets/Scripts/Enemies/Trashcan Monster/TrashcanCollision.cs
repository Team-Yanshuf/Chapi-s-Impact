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

    public void TakeDamageAndApplyPushBack(Vector3 pushback, float damage = 0)
    {
        trashM.takeDamage(damage);
        trashM.Push(pushback);
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
                player.TakeDamageAndApplyPushBack(Vector3.zero, 10);
            }
        }
    }

	public void ApplyPushBack(Vector3 i_Pushback = default)
	{
        trashM.Push(i_Pushback);
	}
}
