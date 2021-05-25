using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyLeaf : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IVulnrable enemy = collision.gameObject.GetComponent<IVulnrable>();
            Vector3 pushback = new Vector3(transform.localScale.x, 0, 0);
            enemy?.takeDamage(Vector3.zero, 10);
        }
    }
}
