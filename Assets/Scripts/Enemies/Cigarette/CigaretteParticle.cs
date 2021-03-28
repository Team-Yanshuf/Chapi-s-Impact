using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CigaretteParticle : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();
        rb = GetComponent<Rigidbody>();

        Vector3 vec = -Physics.gravity/2f;
        Vector3 random = new Vector3(new System.Random().Next(-10, 10), 0, new System.Random().Next(-10, 10));
        Quaternion quat = Quaternion.Euler(40, 0, 0);
        //random = quat * random;
        rb.AddForce(random, ForceMode.Impulse);




        //Vector3 traj = new Vector3(rand.Next(-10, 10), rand.Next(4, 10), rand.Next(-15, 0));
        //Vector3 trajectory = new Vector3(Random.Range(-10,10), Random.Range(4, 10), Random.Range(-15, 0));
        //Quaternion euler = Quaternion.Euler(0, 40, 0);
        ////trajectory = euler * traj;
        //rb.AddForce(traj, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
