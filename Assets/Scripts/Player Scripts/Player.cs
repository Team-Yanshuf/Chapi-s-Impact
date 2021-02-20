using System;
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

    SpriteRenderer renderer;

    // [SerializeField] int health;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    //*******************INPUT FUNCTIONS*****************//
    public void getMovementAxes(ref float horizontal,ref float vertical)
    {
        inputM.getAxes(ref horizontal, ref vertical);
    }

    public void die()
    {
        Debug.Log("CHAPI IS DEAD!!!");
        Destroy(this.gameObject);
    }

    public void takeDamage(float damage)
	{
        healthM.lowerHealthBy(damage);
	}

	public Vector3 getDirectionToMouseNormalized()
    {
        return inputM.getMouseAimDirectionNormalized();
    }


    //******************MOVEMENT FUNCTIONS **************//

    public bool isMoving() => movementM.isMoving();
    public bool isDashing() => movementM.isDash();
    public bool isCollecting() => collisionM.isCollecting();
    public bool isShooting() => attackM.isShooting();
    public void setRendererEnabled(bool enabled) => renderer.enabled = enabled;


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