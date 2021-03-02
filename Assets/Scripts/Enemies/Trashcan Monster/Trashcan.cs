using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    [SerializeField] public GameObject target { get; }
    TrashcanAttacking attackingM;
    TrashcanCollision collisionM;
    TrashcanMovement movementM;
    TrashcanSounds soundM;
    void Start()
    {
        attackingM = GetComponent<TrashcanAttacking>();
        collisionM = GetComponent<TrashcanCollision>();
        movementM = GetComponent<TrashcanMovement>();
        soundM = GetComponent<TrashcanSounds>();
    }


    void Update()
    {
        
    }

}
