using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Component References.
    Player playerM;

    [SerializeField] int speed;
    void Start()
    {
        playerM = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
