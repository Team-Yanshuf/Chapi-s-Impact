using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    WheelMovement movementM;
    WheelCollision collisionM;
    // Start is called before the first frame update
    void Start()
    {
        movementM = GetComponent<WheelMovement>();
        movementM.initSelf();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
