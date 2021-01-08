using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    Player playerM;
    CapsuleCollider hitbox;
    IWeapon staff;
    bool isAttacking;
    void Start()
    {
        staff = GetComponentInChildren<Staff>();
        isAttacking = false;
        hitbox=GetComponentInChildren<CapsuleCollider>();
        playerM = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        attacking();   
    }

    void attacking()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            staff.attack();
        }
    }




}
