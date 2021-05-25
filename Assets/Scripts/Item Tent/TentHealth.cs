using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentHealth : MonoBehaviour
{
    ItemTent tentM;
    int health;

    public void initSelf()
	{
        tentM = GetComponent<ItemTent>();
        health = 100;
	}

	internal void takeDamage(int damage)
	{
        if (health <= damage)
		{
            health = 0;
		}
        else
        health -= damage;
        checkIfAlive();
	}

    void checkIfAlive()
	{
        if (health <= 0)
            tentM.die();
	}
}