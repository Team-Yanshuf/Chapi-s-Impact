using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Component References.
     PlayerMovement movementM;
     PlayerAttacking attackM;
     PlayerInput inputM;
     PlayerHealth healthM;
     PlayerCollision collisionM;
     PlayerAnimation animationM;
     PlayerPlanting plantingM;

    SpriteRenderer renderer;

    bool planting = false;

	// [SerializeField] int health;
	private void Awake()
	{
        movementM = GetComponent<PlayerMovement>();
        attackM = GetComponent<PlayerAttacking>();
        inputM = GetComponent<PlayerInput>();
        healthM = GetComponent<PlayerHealth>();
        collisionM = GetComponent<PlayerCollision>();
        animationM = GetComponent<PlayerAnimation>();
        plantingM = GetComponent<PlayerPlanting>();
	}
	private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    //*******************INPUT FUNCTIONS*****************//
    public void getMovementAxes(ref float horizontal,ref float vertical) => inputM.getMovementAxes(ref horizontal, ref vertical);

    public bool dashPressed() => inputM.dashPressed();
    public bool meleePressed() => inputM.meleePressed();

    public void die()
    {
        Debug.Log("CHAPI IS DEAD!!!");
        GameManagerEvents.chapiDied?.Invoke();
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
    public int comboCount() => attackM.getComboCount();
    public void setRendererEnabled(bool enabled) => renderer.enabled = enabled;
    public bool isPlanting() => planting;
    public bool plantingPressed() => inputM.plantingPressed();
    public void setPlanting(bool planting) => this.planting = planting;

    public float getChapiDirection() => movementM.getChapiDirection();

}