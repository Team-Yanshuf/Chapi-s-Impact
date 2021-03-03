using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float zOffset;
    [SerializeField] float yOffset;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
            return;

        position = player.transform.position - new Vector3(0, yOffset, zOffset);
        transform.position = position;
    }
}

