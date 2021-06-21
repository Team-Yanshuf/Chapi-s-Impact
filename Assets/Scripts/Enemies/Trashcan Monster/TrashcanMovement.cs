using System;
using UnityEngine;

enum Selection
{
    TowardsPlayer,
    AwayFromPlayer
}

public class TrashcanMovement : MonoBehaviour
{
    [SerializeField] Selection movementDirection;
    [SerializeField] float jumpHeight;
    [SerializeField] float jumpDistance;
    
    Trashcan trashM;
    Rigidbody rb;
    Vector3 direction;
    Vector3 movement;

    //For handling bug where the trashcan gets stuck in mid air.
    Timer stuckTimer;
    Vector3 stuckDirection;

    bool moving;
    // Start is called before the first frame update
    void Start()
    {
        trashM = GetComponent<Trashcan>();
        rb = GetComponent<Rigidbody>();
        trashM.addJumpEventListener(jumpMove);
        stuckTimer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        updateDirection();

      //  if (rb.velocity == Vector3.zero)
        {
            if (!stuckTimer.isRunning())
            fireStuckInAirTimer();

           
        }    
        }



    //jumpMove is called by the jumping animation itself, inside the editor.
    void jumpMove()
	{
       // if (trashM.isGrounded()) // && !trashM.isAttacking())
		{
            movement = (-Physics.gravity.normalized * jumpHeight + direction * jumpDistance) * Time.fixedDeltaTime;
            rb.AddForce(movement, ForceMode.Impulse);
            resetMovementVector();
            moving = true;
		}
	}

	internal void push(Vector3 pushback)
	{
        rb.AddForce(pushback, ForceMode.Impulse);
	}

	void resetMovementVector()
	{
        movement = Vector3.zero;	
    }


    void updateDirection()
	{
        if (trashM.target == null)
            return;

        switch(movementDirection)
        {
            case Selection.TowardsPlayer:
                {
                    direction = (trashM.target.transform.position - transform.position).normalized;
                    break;
                }

            case Selection.AwayFromPlayer:
                {
                    direction = (transform.position - trashM.target.transform.position).normalized;
                    break;
                }

        }

	}

    public bool isMoving()
    {
        if (moving)
		{
            moving = false;
            return true;
        }
        return false;

    }
    public float getLookDirection() => direction.x;

    internal void approveJump()
    {
        
    }

    void checkForAirStuck()
	{
        if (!trashM.isGrounded() && rb.velocity==Vector3.zero)
		{
            print("Stuck in the air!!");
            rb.AddForce(-(Physics.gravity*0.5f+stuckDirection*2f), ForceMode.Impulse);
		}
	}

    void fireStuckInAirTimer()
	{
        if (!stuckTimer.isRunning() && rb.velocity==Vector3.zero)
		{
            stuckDirection = direction;
            stuckTimer.setParameters(1.5f, checkForAirStuck);
            stuckTimer.fire();
            print("Started timer");
        }

        else if (stuckTimer.isRunning() && rb.velocity!=Vector3.zero)
		{
            stuckTimer.stop();
		}

	}
}
