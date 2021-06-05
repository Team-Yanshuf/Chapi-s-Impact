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

    bool moving;
    // Start is called before the first frame update
    void Start()
    {
        trashM = GetComponent<Trashcan>();
        rb = GetComponent<Rigidbody>();
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
       // if (trashM.isGrounded()) // && !trashM.isAttacking())
		{
            movement = (-Physics.gravity.normalized * jumpHeight + direction * jumpDistance) * Time.fixedDeltaTime;
            rb.AddForce(movement, ForceMode.Impulse);
            resetMovementVector();
            moving = true;
		}
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
}
