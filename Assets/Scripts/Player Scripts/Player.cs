using UnityEngine;

public class Player : MonoBehaviour
{

    //Component References.
    [SerializeField] PlayerMovement movementM;
    [SerializeField] PlayerAttacking attackM;
    [SerializeField] PlayerInput inputM;
    [SerializeField] PlayerHealth healthM;
    [SerializeField] PlayerCollision collisionM;
    [SerializeField] PlayerAnimation animationM;

    [SerializeField] int health;



    //*******************INPUT FUNCTIONS*****************//
    public void getMovementAxes(ref float horizontal,ref float vertical)
    {
        inputM.getAxes(ref horizontal, ref vertical);
    }
   public Vector3 getDirectionToMouseNormalized()
    {
        return inputM.getMouseAimDirectionNormalized();
    }


    //******************MOVEMENT FUNCTIONS **************//

    public bool isMoving()
    {
        return movementM.isMoving();
    }

    public bool isDashing()
    {
        return movementM.isDash();

    }

    public bool isCollecting()
    {
        return collisionM.isCollecting();
    }
}
/* Implementation of the player manager as a state machine.
 * 
 * if isMoving, state is moving
 * 
 * if hurt, state is hurt.
 * 
 * if colliding, state is colliding.
 * 
 * 
 */