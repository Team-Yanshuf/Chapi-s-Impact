using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanMovement : MonoBehaviour
{
    [SerializeField] float jumpHeight;
    Trashcan trashM;
    Rigidbody rb;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        trashM = GetComponent<Trashcan>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 jump = Physics.gravity.normalized;
        if (Input.GetKeyDown(KeyCode.U))
		{
            rb.AddForce(-jump*jumpHeight, ForceMode.Impulse);
		}
    }

    void updateDirection()
	{
        direction = transform.position - trashM.target.transform.position;
	}
}
