using System;
using UnityEngine;

public struct PlayerInfo
{
    // hello
    public bool isMoving {get; set;}
    public bool isControlledByPlayer { get; set; }
    public bool isPlanting { get; set; }
    public bool isAttacking { get; set; }

    public int attackNumber { get; set; }

    public float horizontal { get; set; }
    public float vertical { get; set; }
    public Vector3 movement { get; set; }
    public float speed { get; set; }
    public Room currentRoom { get; set; }
}
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
    public WeaponManager weaponM;
    PlayerPowerup powerupM;

    Room currentRoom;

    SpriteRenderer renderer;
    Timer timer;

    int treesToPlant = 0;
    bool planting = false;

    [SerializeField] bool isControlledByPlayer;



	private void Awake()
	{
        movementM = GetComponent<PlayerMovement>();
        attackM = GetComponent<PlayerAttacking>();
        inputM = GetComponent<PlayerInput>();
        healthM = GetComponent<PlayerHealth>();
        collisionM = GetComponent<PlayerCollision>();
        animationM = GetComponent<PlayerAnimation>();
        plantingM = GetComponent<PlayerPlanting>();
        weaponM = GetComponentInChildren<WeaponManager>();
        powerupM = GetComponent<PlayerPowerup>();
	}
	private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        weaponM.initSelf();
        powerupM.initSelf();
    }

    //*******************INPUT FUNCTIONS*****************//
    public void getMovementAxes(ref float horizontal,ref float vertical) => inputM.getMovementAxes(ref horizontal, ref vertical);
    public Vector3 getActualMovement() => movementM.getActualMovement();
    public bool dashPressed() => inputM.dashPressed();
    public bool meleePressed() => inputM.meleePressed();

    public void die()
    {
        GameManagerEvents.chapiDied?.Invoke();
        Destroy(this.gameObject);
    }

    public void takeDamage(Vector3 pushback, float damage)
	{
        healthM.lowerHealthBy(damage);
        movementM.applyPushback(pushback);
	}

	public Vector3 getDirectionToMouseNormalized()
    {
        return inputM.getMouseAimDirectionNormalized();
    }

    public int getHP() => healthM.getHP();


    //******************MOVEMENT FUNCTIONS **************//

    public bool isMoving() => movementM.isMoving();
    public bool isDashing() => movementM.isDash();
    public bool isCollecting() => collisionM.isCollecting();
    public PlayerMovementInfo GetMovementInfo() => movementM.getMovementInfo();
	internal void grantPlantPremission()
	{
        treesToPlant++;
	}

	public bool isShooting() => attackM.isShooting();
    public bool isHurt() => collisionM.isHurt();
    public bool isPlanting() => planting;
    
    //**********MIGHT NOT BE NECCECERY************//
    public bool isDead() => healthM.isDead();
    //**********MIGHT NOT BE NECCECERY************//


    public bool plantingPressed() => inputM.plantingPressed();
    public bool shootingPressed() => inputM.shootPressed();


    public int comboCount() => attackM.getComboCount();
    public bool isAttacking() => attackM.isAttacking();
    public void setRendererEnabled(bool enabled) => renderer.enabled = enabled;
    public void setPlanting(bool planting)
    {
        treesToPlant--;
        this.planting = planting;
    }
    public float getChapiDirection() => movementM.getChapiDirection();
    public int getHowManyTreesCanPlant() => treesToPlant;


    public PlayerInfo getPlayerInfo()
	{
        PlayerInfo info = new PlayerInfo();
        Vector3 movement = getActualMovement();

        info.isControlledByPlayer = isControlledByPlayer;
        info.isAttacking = isAttacking();
        info.attackNumber = comboCount();
        info.isPlanting = isPlanting();
        info.isMoving = isMoving();
        info.horizontal = movement.x;
        info.vertical = movement.z;
        info.movement = movement;
        info.speed = movement.magnitude;

        return info;
	}

    public void movePlayerBetweenRooms(Vector3 position, Room roomTo)
	{
        currentRoom = roomTo;
        plantingM.setRoom(currentRoom);

        gameObject.layer = LayerMask.NameToLayer("PlayerDash");
        transform.position = position;

        timer = GetComponent<Timer>();

		timer.setParameters(1, returnToNormal);
		timer.fire();
		void returnToNormal()
		{
            gameObject.layer = LayerMask.NameToLayer("Player");
		}
	}

    public void updateCurrentRoom(Room room)
	{
        this.currentRoom = room;
	}

    public Room getRoom() => currentRoom;
    public void changeCollisionLayerDuringDash() => collisionM.changeCollisionLayerDuringDash();

    public void revokePlayerControl(string direction)
	{
        isControlledByPlayer = false;
        movementM.setFauxMovementVector(direction);
        //change isControlledByPlayer to false.
        //this will cause movement, planting and attacking to lock up.
        //make sure camera listens to isControlledByPlayer.
        //when called, make movement script make chapi move in his direction.
        //inside collision script, fill block for begin bridge and end bridge.

        //in begin, make player start walking.
        //in end, make player teleport and free movement for player.
	}

    internal void restorePlayerControl()
    {
        isControlledByPlayer = true;
    }

}