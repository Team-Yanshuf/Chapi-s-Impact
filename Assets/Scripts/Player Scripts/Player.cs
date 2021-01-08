using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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




    public void getMovementAxes(ref float horizontal,ref float vertical)
    {
        inputM.getAxes(ref horizontal, ref vertical);
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
