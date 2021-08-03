using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMovement : MonoBehaviour
{
    Wheel wheelM;
    Vector3 directionVector;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] GameObject target;

    Timer timer;
    Rigidbody rb;
    public void initSelf()
	{
        wheelM = GetComponent<Wheel>();
        rb = GetComponent<Rigidbody>();
        timer = GetComponent<Timer>();

        InvokeRepeating("setWheelSprint",3, 3);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
    private void setMovementVector()
	{
        directionVector = (target.transform.position - transform.position).normalized;
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
