using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct WheelMovementInfo
{
    public Vector3 VelocityVector { get; set; }
    public Vector3 DirectionVector { get; set; }
    public bool Accelerating { get; set; }
    public bool Decelerating { get; set; }

    public WheelMovementInfo(Vector3 i_VelocityVector, Vector3 i_DirectionVector, bool i_Accelerating, bool i_Decelerating)
	{
        VelocityVector = i_VelocityVector;
        DirectionVector = i_DirectionVector;
        Accelerating = i_Accelerating;
        Decelerating = i_Decelerating;
	}
}


public class WheelMovement : MonoBehaviour
{
    Wheel wheelM;
    Vector3 directionVector;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;
    
    bool m_Decelerating;
    bool m_Accelerating;

    Rigidbody rb;

    Vector3 previousVelocity;
    public void InitSelf()
	{
        wheelM = GetComponent<Wheel>();
        rb = GetComponent<Rigidbody>();
        wheelM.GetWheelEvents().wheelSprint.AddListener(setWheelSprint);
        previousVelocity = Vector3.zero;
	}

	public void LateUpdate()
	{
        previousVelocity = rb.velocity;
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
        dectectDecelerationOrAcceleration();
        return new WheelMovementInfo(rb.velocity, directionVector, m_Accelerating, m_Decelerating);
	}

    private void dectectDecelerationOrAcceleration()
	{
        m_Accelerating = rb.velocity.magnitude > previousVelocity.magnitude;
        m_Decelerating = rb.velocity.magnitude < previousVelocity.magnitude;
    }

    public void ApplyPushback(Vector3 i_Pushback)
	{
        rb.AddForce(i_Pushback, ForceMode.Impulse);
	}
}
