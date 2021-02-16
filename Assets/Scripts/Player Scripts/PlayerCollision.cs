using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour, IVulnrable
{

    Player playerM;
    bool collecting;


    private void Start()
    {
        playerM = GetComponent<Player>();
    }


    public bool isCollecting()
    {
        bool temp = collecting;
        collecting = false;
        return temp;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
            collecting = true;
    }

    public void takeDamage(float damage)
    {
        playerM.takeDamage(damage);
    }
}
