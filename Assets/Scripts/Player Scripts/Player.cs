using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Component References.
    [SerializeField] PlayerMovement movementM;
    [SerializeField] PlayerAttacking attackM;
    [SerializeField] PlayerInput inputM;
    [SerializeField] PlayerHealth healthM;

    [SerializeField] int health;


    void Start()
    {

    }


    void Update()
    {
        
    }
}
