using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{ 
    private FMOD.Studio.EventInstance instance;

[FMODUnity.EventRef]
public string fmodEvent;

[SerializeField]
[Range(0f, 1f)]
private float Walking;

    // Start is called before the first frame update
    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
    }

    // Update is called once per frame
    void Update()
    {
        instance.setParameterByName("Walking", Walking);

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            instance.start();
            Walking = 1f;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Walking = 0f;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            instance.start();
            Walking = 1f;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Walking = 0f;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            instance.start();
            Walking = 1f;

        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Walking = 0f;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            instance.start();
            Walking = 1f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Walking = 0f;
        }
    }
}
