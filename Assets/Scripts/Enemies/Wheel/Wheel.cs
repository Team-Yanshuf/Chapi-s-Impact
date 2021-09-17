using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour, IEnemy
{
    WheelMovement movementM;
    WheelCollision collisionM;
    WheelEvents eventsM;
    WheelAnimation animationM;
    WheelHealth healthM;
    WheelStates statesM;
    RoomEvents currentRoomEvents;
    
    GameObject target;

    void Start()
    {
        target = LevelManager.player.gameObject;

        eventsM = GetComponent<WheelEvents>();
        eventsM.InitSelf();

        movementM = GetComponent<WheelMovement>();
        movementM.InitSelf();

        animationM = GetComponent<WheelAnimation>();
        animationM.InitSelf();

        collisionM = GetComponent<WheelCollision>();
        collisionM.InitSelf();

        healthM = GetComponent<WheelHealth>();
        healthM.InitSelf();

        statesM = GetComponent<WheelStates>();
        statesM.InitSelf();
    }

    public WheelEvents GetWheelEvents()
	{
        return eventsM;
	}

	internal void Die()
	{
		GameManagerEvents.OnEnemyDefeated();
		currentRoomEvents?.dwindleLocalFog.Invoke();
        Destroy(gameObject);
	}

	internal void TakeDamage(float i_Damage)
	{
        healthM.ReductHP((int) i_Damage);
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

	void IEnemy.setRoomEvents(RoomEvents i_RoomEvents)
	{
        currentRoomEvents = i_RoomEvents;
	}

    public WheelStatesInfo GetWheelStatesInfo()
	{
        return statesM.GetWheelStateInfo();
	}
}
