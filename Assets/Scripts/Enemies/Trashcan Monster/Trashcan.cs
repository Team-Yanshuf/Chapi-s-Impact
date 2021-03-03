using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    public GameObject target; 
    TrashcanAttacking attackingM;
    TrashcanCollision collisionM;
    TrashcanMovement movementM;
    TrashcanSounds soundM;

    [SerializeField] float maxHp;
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

    public bool isMoving() => movementM.isMoving();
    public bool isAttacking() => attackingM.isAttacking();
    public float getMaxHP() => maxHp;

    public void die()
	{
        soundM.playDie();
        Destroy(this.gameObject);
	}

    //PLACE HOLDER!!!
    public bool isHurt() => false;
}
