using System;
using System.Collections;
using UnityEngine;


public struct PlayerMovementInfo
{
    public bool isDashing { get; }

    public PlayerMovementInfo(bool isDashing)
	{
        this.isDashing = isDashing;
	}

    public static Vector3 transformVectorToFitPlane(Vector3 vec)
	{
        Quaternion q = Quaternion.Euler(40, 0, 0);
        return q * vec;
	}
}
public class PlayerMovement : MonoBehaviour
{
    PlayerMovementInfo info;

    //Component References.
    Player playerM;
    Rigidbody rb;
    Vector3 movement;
    [SerializeField] float groundRotation;
    [SerializeField] float speed;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashLength;

    Vector3 FauxMovementForRoomTraversal;

    float direction, horizontal, vertical;
    bool isDashing;

    void Start()
    { 
        playerM = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        isDashing = false;
        direction = 1;
    }
    void Update()
    {
        if(playerM.getPlayerInfo().isControlledByPlayer)
		{
            setMovementVector();

            if (!playerM.isPlanting() && !playerM.isAttacking())
                move();

            handleWeaponDirection();
        }

        else
		{
            movePlayerBetweenRooms();
            handleWeaponDirection();
		}

    }

    void movePlayerBetweenRooms()
	{
        rb.MovePosition(transform.position + FauxMovementForRoomTraversal);
	}
    private void setMovementVector()
    {
        if (playerM.isPlanting() || playerM.isAttacking())
		{
            movement = Vector3.zero;
            return;
		}

        playerM.getMovementAxes(ref horizontal, ref vertical);
        movement = new Vector3(horizontal, vertical, 0);
        Quaternion rotation = Quaternion.Euler(groundRotation, 0, 0);
        movement = rotation * movement;
    }
    void move()
    {
         if (Input.GetKeyDown(KeyCode.C))
        {
            dash();
        }

        else
        {
            //isDashing = false;
            rb.MovePosition(transform.position + movement * speed * Time.deltaTime *60f);
        }
    }
	internal void applyPushback(Vector3 pushback)
	{
        rb.AddForce(pushback, ForceMode.Impulse);
	}
	public bool isMoving()
    {
        return movement.magnitude != 0;
    }
    public Vector3 getActualMovement() => movement;
    public bool isDash()
    {
        return isDashing;
    }
    void dash()
    {
        StartCoroutine(dashCoroutine());
        IEnumerator dashCoroutine()
        {
            if (movement.magnitude == 0)
                yield break;

            Vector3 currentMovement = movement;
            isDashing = true;
            playerM.changeCollisionLayerDuringDash();
            for (int i = 0; i < dashLength; i++)
            {
                rb.MovePosition(transform.position + (currentMovement * (dashSpeed / dashLength)) * Time.deltaTime * 60f);
                yield return null;
            }
            isDashing = false;
            playerM.changeCollisionLayerDuringDash();
        }
    }

    void handleWeaponDirection()
	{
        Transform weapon = GetComponentInChildren<CapsuleCollider>().gameObject.transform;
        if (movement.x != 0)
        {
            if (movement.x<0)
			{
                Quaternion val1= new Quaternion(0, (float)(Math.Floor(movement.x)), 0,0);
                Quaternion val2 = Quaternion.Euler(0, 180, 0);
                weapon.rotation = val1;
 
			}

            else
			{
                weapon.rotation = Quaternion.Euler(0, 0, 0);
			}
        }

        else if (movement.z!=0)
		{
            if (movement.z>0)
			{
                weapon.rotation = Quaternion.Euler(0, -90, 40);
			}

            else
			{
                weapon.rotation = Quaternion.Euler(0, 90, -40);
			}
		}
	}
    public float getChapiDirection()
	{
        if (movement.x != 0)
        {
            direction = movement.x;
            return sign(movement.x);

        }
        else
		{
            return sign(direction);
        }
	}
    int sign(float num)
	{
        if (num == 0)
            return 0;

        if (num > 0)
            return 1;
        else
            return -1;
	}

    public void setSpeed(float speed)
	{
        this.speed = speed;
	}
    public float getSpeed() => speed;

    public PlayerMovementInfo  getMovementInfo()
	{
        info = new PlayerMovementInfo(isDashing);
        return info;
	}

	internal void setFauxMovementVector(string direction)
	{
		switch (direction)
		{
            case "Top":
				{
                    FauxMovementForRoomTraversal = PlayerMovementInfo.transformVectorToFitPlane(new Vector3(0, 1, 0));
                    break;
				}

            case "Bottom":
				{
                    FauxMovementForRoomTraversal = PlayerMovementInfo.transformVectorToFitPlane(new Vector3(0, -1, 0));
                    break;
				}

            case "Left":
				{
                    FauxMovementForRoomTraversal = PlayerMovementInfo.transformVectorToFitPlane(new Vector3(-1,0, 0));
                    break;
				}

            case "Right":
				{
                    FauxMovementForRoomTraversal = PlayerMovementInfo.transformVectorToFitPlane(new Vector3(1, 0, 0));
                    break;
				}
		}
	}
}