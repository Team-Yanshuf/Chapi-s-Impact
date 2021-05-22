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

	private void Update()
	{
        //changeCollisionLayerDuringDash();
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
        playerM.takeDamage(pushback,damage);
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


    public void changeCollisionLayerDuringDash()
	{
        if (playerM.getMovementInfo().isDashing)
		{
            gameObject.layer = LayerMask.NameToLayer("PlayerDash");

        }


		else
		{
			gameObject.layer = LayerMask.NameToLayer("Player");
		}
	}
}
