using UnityEngine.Events;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    public GameObject target; 
    TrashcanAttacking attackingM;
    TrashcanCollision collisionM;
    TrashcanMovement movementM;
    TrashcanSounds soundM;
    TrashcanEvents eventM;

    [SerializeField] float maxHp;
    void Start()
    {
        eventM = GetComponent<TrashcanEvents>();
        attackingM = GetComponent<TrashcanAttacking>();
        collisionM = GetComponent<TrashcanCollision>();
        movementM = GetComponent<TrashcanMovement>();
        soundM = GetComponent<TrashcanSounds>();


        if (eventM == null)
            print("NULLLL!!");

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



    //****Event Functions*****

    public void invokeJumpEvent() => TrashcanEvents.jump.Invoke();
    public void addJumpEventListener(UnityAction call) => TrashcanEvents.jump.AddListener(call);
    public void invokeLandEvent() => TrashcanEvents.land.Invoke();
    public void addLandEventListener(UnityAction call) => TrashcanEvents.land.AddListener(call);




    //public void invokeJumpEvent() => eventM.invokeJumpEvent();
    //public void addJumpEventListener(UnityAction action)
    //{
    //    if (eventM==null)
    //    {
    //        print("eventM is null");
    //        return;
    //    }
    //    eventM.addJumpListener(action);
    //}
    ////=> eventM.jump.AddListener(action);
    //public void invokeLandEvent() => eventM.invokeLandEvent();
    //public void addLandEventListener(UnityAction action) => eventM.addLandListener(action);


}
