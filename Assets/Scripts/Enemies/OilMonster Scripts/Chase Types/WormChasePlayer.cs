using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormChasePlayer : MonoBehaviour
{
    OilMonster oilMonsterM;
    [SerializeField] float speed;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        oilMonsterM = GetComponent<OilMonster>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oilMonsterM.isAgroed() && !oilMonsterM.isHurt())
        wormFollow();
    }

    void follow()
    {
        Vector3 direction = (oilMonsterM.getTargetPosition() - transform.position).normalized;
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }

	internal void pushback(Vector3 pushback)
	{
        rb.AddForce(pushback,ForceMode.Impulse);
	}

	void wormFollow()
    {
        if (oilMonsterM.isCrawling())
            follow();
    }


}
