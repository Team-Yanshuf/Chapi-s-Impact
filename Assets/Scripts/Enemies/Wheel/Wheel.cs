using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    WheelMovement movementM;
    WheelCollision collisionM;
    WheelEvents eventsM;
    WheelAnimation animationM;

    [SerializeField] GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        eventsM = GetComponent<WheelEvents>();
        eventsM.InitSelf();

        movementM = GetComponent<WheelMovement>();
        movementM.InitSelf();

 


        animationM = GetComponent<WheelAnimation>();
        animationM.InitSelf();

        collisionM = GetComponent<WheelCollision>();
        collisionM.InitSelf();

    }

    public WheelEvents GetWheelEvents()
	{
        return eventsM;
	}

    public void ApplyDamage(float Damage)
	{

	}

    public void ApplyPushback(Vector3 i_Pushback)
	{
        movementM.ApplyPushback(i_Pushback);
	}

    public WheelMovementInfo GetWheelMovementInfo()
	{
        return movementM.GetWheelMovementInfo();
	}

    public GameObject GetTarget()
	{
        return target;
	}
}
