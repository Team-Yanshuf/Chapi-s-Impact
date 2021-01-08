using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    bool collecting;




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
}
