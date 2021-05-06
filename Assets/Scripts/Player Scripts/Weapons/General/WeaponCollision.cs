using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy") && !collision.isTrigger)
        {
            IVulnrable enemy = collision.GetComponent<IVulnrable>();
            Vector3 pushback = new Vector3(transform.localScale.x, 0, 0);
            enemy?.takeDamage(pushback * 5, 25);
        }
    }
}
