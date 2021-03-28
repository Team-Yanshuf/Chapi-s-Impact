using UnityEngine.Events;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    public GameObject target; 
    TrashcanAttacking attackingM;
    TrashcanCollision collisionM;
    TrashcanMovement movementM;
    TrashcanSounds soundM;
    //TrashcanEvents eventM;

    int landCounter;

    [SerializeField] float maxHp;
    void Start()
    {
        //eventM = GetComponent<TrashcanEvents>();
        attackingM = GetComponent<TrashcanAttacking>();
        collisionM = GetComponent<TrashcanCollision>();
        movementM = GetComponent<TrashcanMovement>();
        soundM = GetComponent<TrashcanSounds>();

        TrashcanEvents.land.AddListener(incrementLandCounter);

        landCounter = 0;
    }

    public bool isMoving() => movementM.isMoving();
    public bool isAttacking() => attackingM.isAttacking();
    public float getMaxHP() => maxHp;

    public bool isGrounded() => collisionM.isGrounded();
    public float getLookDirection() => movementM.getLookDirection();

    public void die()
	{
        soundM.playDie();
        Destroy(this.gameObject);
	}

    //PLACE HOLDER!!!
    public bool isHurt() => false;


    public void incrementLandCounter() => landCounter++;
    public bool canAttackBasedOnLands()
    {
        if (landCounter>=2)
        {
            landCounter = 0;
            return true;
        }
        return false;
    }
        //=> landCounter;


    //****Event Functions*****

    public void invokeJumpEvent() => TrashcanEvents.jump.Invoke();
    public void addJumpEventListener(UnityAction call) => TrashcanEvents.jump.AddListener(call);
    public void invokeLandEvent() => TrashcanEvents.land.Invoke();
    public void addLandEventListener(UnityAction call) => TrashcanEvents.land.AddListener(call);


    void decideNextAction()
    {
        if (canAttackBasedOnLands())
            attackingM.approveAttack();

        else
            movementM.approveJump();
    }

}
