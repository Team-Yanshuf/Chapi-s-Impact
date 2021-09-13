using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct WheelMovementInfo
{
    public Vector3 VelocityVector { get; set; }
    //public float Speed { get; set; }

    public Vector3 DirectionVector { get; set; }
    public WheelMovementInfo(Vector3 i_VelocityVector, Vector3 i_DirectionVector)
	{
        VelocityVector = i_VelocityVector;
        DirectionVector = i_DirectionVector;
	}
}


public class WheelMovement : MonoBehaviour
{
    Wheel wheelM;
    Vector3 directionVector;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;

    Timer timer;
    Rigidbody rb;

    Vector3 previousVelocity;
    public void InitSelf()
	{
        wheelM = GetComponent<Wheel>();
        rb = GetComponent<Rigidbody>();
        timer = GetComponent<Timer>();

        wheelM.GetWheelEvents().wheelSprint.AddListener(setWheelSprint);
        previousVelocity = Vector3.zero;
	}

	public void Update()
	{
        if(rb.velocity.magnitude > 5f)
		{
            DetectSevereVelocityChange();
            previousVelocity = rb.velocity;
        }
    }

	private void setMovementVector()
	{
        directionVector = (wheelM.GetTarget().transform.position - transform.position).normalized;
	}
    private void sprint()
	{

        rb.AddForce(directionVector * sprintSpeed, ForceMode.Impulse);
	}
    private void setWheelSprint()
	{
        setMovementVector();
        sprint();
	}

    public WheelMovementInfo GetWheelMovementInfo()
	{
        return new WheelMovementInfo(rb.velocity, directionVector);
	}

    public void ApplyPushback(Vector3 i_Pushback)
	{
        rb.AddForce(i_Pushback, ForceMode.Impulse);
	}

    public bool DetectSevereVelocityChange()
	{
		float deltaVelocity = previousVelocity.magnitude / rb.velocity.magnitude;
        //print(deltaVelocity);
        
        if (deltaVelocity < 0.05f)
		{
			wheelM.GetWheelEvents().OnWheelCollidedWithWall();
			return true;
		}

        return false;
	}




    /*
     * Wheel is going to be a non format state machine implementation.
     * The wheel will transition between animations and movements based on a timer.
     * The same timer will be reset and reused to time the next transition when the current one ends. 
     * each timer function will run and then activate the next timer.
     * The Wheel cycle is:
     * Idle -> Startup -> Sprint -> Collision -> Stars 
     *  ^                                            |
     *  |------------------------------------------ <
     */

    private void setIdleTimer()
	{

	}

    private void setStartupTimer()
	{

	}

    private void setStarsTimer()
	{

	}
}
