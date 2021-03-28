using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanMovement : MonoBehaviour
{
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
       // jumpMove();
    }



    //jumpMove is called by the jumping animation itself, inside the editor.
    void jumpMove()
	{
        if (trashM.isGrounded())
		{
            print((-Physics.gravity.normalized * jumpHeight + direction * jumpDistance) * Time.fixedDeltaTime);
            rb.AddForce((-Physics.gravity.normalized*jumpHeight + direction*jumpDistance)*Time.fixedDeltaTime, ForceMode.Impulse);
		}
	}



    void updateDirection()
	{
        if (trashM.target == null)
            return;

        direction = (trashM.target.transform.position - transform.position).normalized;
	}

    public bool isMoving() => movement.magnitude != 0;

    public float getLookDirection() => direction.x;
}
