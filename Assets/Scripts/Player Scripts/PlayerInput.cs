using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Player playerM;

    float horizontal, vertical;
    void Start()
    {
        playerM = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getAxes(ref float horizontal,ref float vertical)
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

}
