using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FMODUnity.StudioListener))]
public class SetAttenuation : MonoBehaviour
{
    [SerializeField] FMODUnity.StudioListener listener;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        listener.attenuationObject = player;
    }
}
