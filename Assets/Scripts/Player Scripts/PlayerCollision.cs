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
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Collectible"))
		{
            collecting = true;
            PowerupInfo info =  other.gameObject.GetComponent<PowerupBase>().getPowerupInfo();

            GetComponent<PlayerPowerup>().addNewPowerup(info);
            other.gameObject.GetComponent<PowerupBase>().destroy();
        }
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("BridgeStart"))
        {
            Bridge bridge = other.GetComponent<Bridge>();
            if (bridge.getBridgeInfo().isOpen)
			{
                gameObject.layer = LayerMask.NameToLayer("PlayerTraverseRooms");
                playerM.revokePlayerControl(bridge.getBridgeInfo().direction);
                bridge.exitRoom();
            }

        }

        else if (other.gameObject.CompareTag("BridgeEnd"))
        {
            Bridge bridge = other.GetComponentInParent<Bridge>();

            bridge.enterNextRoom();
            other.GetComponentInParent<Bridge>().movePlayer();
            playerM.restorePlayerControl();

        }
    }

	public void TakeDamageAndApplyPushBack(Vector3 pushback, float damage = 0)
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
        if (playerM.GetMovementInfo().isDashing)
		{
            gameObject.layer = LayerMask.NameToLayer("PlayerDash");
        }


		else
		{
			gameObject.layer = LayerMask.NameToLayer("Player");
		}
	}

	public void ApplyPushBack(Vector3 i_Pushback = default)
	{
        //for now, nothing. 
        //To Do: Create a pushback only method.
		throw new System.NotImplementedException();
	}
}
