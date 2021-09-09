using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelHealth : MonoBehaviour
{
    Wheel wheelM;
    [SerializeField] int maxHealth;
    int currentHealth;
    bool isReady = false;



    // Start is called before the first frame update
    public void InitSelf()
    {
        wheelM = GetComponent<Wheel>();
        currentHealth = maxHealth;
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
		{
            CheckIfAlive();
        }
    }

    public void ReductHP(int damage = 0)
	{
        currentHealth -= damage;
	}

    private void CheckIfAlive()
	{

        if (currentHealth <= 0)
		{
            print($"Current health: {currentHealth}");
            wheelM.Die();

		}
	}
}
