using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanMovement : MonoBehaviour
{
    [SerializeField] float jumpHeight;
    Trashcan trashM;
    Rigidbody rb;
    Vector3 direction;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        trashM = GetComponent<Trashcan>();
        rb = GetComponent<Rigidbody>();
        TrashcanEvents.jump.AddListener(jumpMove);
    }

    // Update is called once per frame
    void Update()
    {
        updateDirection();
    }



    void jumpMove()
	{
        if (rb.velocity==Vector3.zero)
		{
            Debug.Log(-Physics.gravity + direction * jumpHeight);


            rb.AddForce((-Physics.gravity.normalized * jumpHeight + direction)*Time.deltaTime , ForceMode.VelocityChange);
		}
	}



    void updateDirection()
	{
        direction = (trashM.target.transform.position - transform.position).normalized;
	}

    public bool isMoving() => movement.magnitude != 0;
}
