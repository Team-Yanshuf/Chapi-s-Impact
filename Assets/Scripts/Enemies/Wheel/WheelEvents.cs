using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class WheelEvents : MonoBehaviour
{
    public UnityEvent wheelIdle;
    public UnityEvent wheelStarted;
    public UnityEvent wheelSprint;
    public UnityEvent wheelCollidedWithWall;
    public UnityEvent wheelCollidedWithChapi;

    public void InitSelf()
	{
        wheelIdle = new UnityEvent();
        wheelStarted = new UnityEvent();
        wheelSprint = new UnityEvent();
        wheelCollidedWithWall = new UnityEvent();
        wheelCollidedWithChapi = new UnityEvent();
    }

    public void OnWheelCollidedWithWall()
	{
        wheelCollidedWithWall.Invoke();
	}

    public void OnWheelIdle()
	{
        wheelIdle.Invoke();
	}

    public void OnWheelStarted()
	{
        wheelStarted.Invoke();
	}

    public void OnWheelSprint()
	{
        wheelSprint.Invoke();
	}

    public void OnWheelCollidedWithChapi()
	{
        wheelCollidedWithChapi.Invoke();
	}
}
