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
        print($"Fired! with direction of {directionVector} and speed of {sprintSpeed}");
        rb.AddForce(directionVector * sprintSpeed, ForceMode.Impulse);
	}
    

    private void setWheelSprint()
	{
        setMovementVector();
        sprint();
	}
}
