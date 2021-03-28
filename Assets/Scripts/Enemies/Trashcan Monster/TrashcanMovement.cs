using System;
using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        trashM = GetComponent<Trashcan>();
        rb = GetComponent<Rigidbody>();
        //TrashcanEvents.jump.AddListener(jumpMove);
        trashM.addJumpEventListener(jumpMove);
    }

    // Update is called once per frame
    void Update()
    {
        updateDirection();
    }



    //jumpMove is called by the jumping animation itself, inside the editor.
    void jumpMove()
	{
        if (trashM.isGrounded()) // && !trashM.isAttacking())
		{
            //print((-Physics.gravity.normalized * jumpHeight + direction * jumpDistance) * Time.fixedDeltaTime);
            rb.AddForce((-Physics.gravity.normalized*jumpHeight + direction*jumpDistance)*Time.fixedDeltaTime, ForceMode.Impulse);
		}
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

    public bool isMoving() => movement.magnitude != 0;

    public float getLookDirection() => direction.x;

    internal void approveJump()
    {
        
    }
}
