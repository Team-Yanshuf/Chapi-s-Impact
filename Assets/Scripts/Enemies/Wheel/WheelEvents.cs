using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class WheelEvents : MonoBehaviour
{
    private UnityEvent wheelIdle;
    private UnityEvent wheelStarted;
    private UnityEvent wheelSprint;
    private UnityEvent wheelCollidedWithWall;
    private UnityEvent wheelCollidedWithChapi;

    // Start is called before the first frame update
    void Start()
    {
        wheelIdle = new UnityEvent();
        wheelStarted = new UnityEvent();
        wheelSprint = new UnityEvent(); 
        wheelCollidedWithWall = new UnityEvent();
        wheelCollidedWithChapi = new UnityEvent();
    }
}
