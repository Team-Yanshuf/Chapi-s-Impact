using UnityEngine;

public class Player : MonoBehaviour
{

    //Component References.
    [SerializeField] PlayerMovement movementM;
    [SerializeField] PlayerAttacking attackM;
    [SerializeField] PlayerInput inputM;
    [SerializeField] PlayerHealth healthM;
    [SerializeField] PlayerCollision collisionM;

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
    public bool isMoving()
    {
        return movementM.isMoving();
    }

    public bool isCollecting()
    {
        return collisionM.isCollecting();
    }
}
