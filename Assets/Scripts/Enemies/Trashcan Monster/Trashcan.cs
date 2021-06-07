using UnityEngine;
using UnityEngine.Events;

public class Trashcan : MonoBehaviour, IEnemy
{
    public GameObject target; 
    TrashcanAttacking attackingM;
    TrashcanCollision collisionM;
    TrashcanMovement movementM;
    TrashcanSounds soundM;
    TrashcanHealth healthM;
    TrashcanEvents eventM;

    int currentJumpMax;
    int landCounter;

    [SerializeField] float maxHp;
	private RoomEvents currentRoomEvents;

	void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        attackingM = GetComponent<TrashcanAttacking>();
        
        collisionM = GetComponent<TrashcanCollision>();
        collisionM.initSelf();
        
        movementM = GetComponent<TrashcanMovement>();
        soundM = GetComponent<TrashcanSounds>();
        healthM = GetComponent<TrashcanHealth>();
        eventM = GetComponent<TrashcanEvents>();

        eventM.initSelf();
        eventM.land.AddListener(incrementLandCounter);

        landCounter = 0;
        currentJumpMax = Random.Range(1, 5);
    }

	internal void push(Vector3 pushback)
	{
        movementM.push(pushback);
	}

	internal void takeDamage(float damage)
	{
        healthM.reductHP(damage);
	}

	public bool isMoving() => movementM.isMoving();
    public bool isAttacking() => attackingM.isAttacking();
    public float getMaxHP() => maxHp;

    public bool isGrounded() => collisionM.isGrounded();
    public float getLookDirection() => movementM.getLookDirection();

    public void die()
	{
        currentRoomEvents.dwindleLocalFog.Invoke();
        soundM.playDie();

        Destroy(this.gameObject);
	}

    //PLACE HOLDER!!!
    public bool isHurt() => collisionM.isHurt();


    public void incrementLandCounter() => landCounter++;
    public bool canAttackBasedOnLands()
    {
        if (landCounter>currentJumpMax)
        {
            landCounter = 0;
            currentJumpMax = Random.Range(1, 5);
            return true;
        }
        return false;
    }


    //****Event Functions*****

    public void invokeJumpEvent() => eventM.jump.Invoke();
    public void addJumpEventListener(UnityAction call) => eventM.jump.AddListener(call);
    public void invokeLandEvent() => eventM.land.Invoke();
    public void addLandEventListener(UnityAction call) => eventM.land.AddListener(call);


    void decideNextAction()
    {
        if (canAttackBasedOnLands())
            attackingM.approveAttack();

        else
            movementM.approveJump();
    }

	public void setRoomEvents(RoomEvents roomEvents)
	{
        this.currentRoomEvents = roomEvents;
	}
}