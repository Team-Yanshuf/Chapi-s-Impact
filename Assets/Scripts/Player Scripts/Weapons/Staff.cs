using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon
{
    bool canHit;
    [SerializeField] float damage;
    [SerializeField] float attackDuration;
    float attackStartTime;
    CapsuleCollider hitbox;
    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canHit)
        {
            if (attackStartTime + attackDuration > Time.realtimeSinceStartup)
            {
                canHit = false;
                hitbox.enabled = false;
            }
        }
    }

    public void attack()
    {
        canHit = true;
        hitbox.enabled = true;
        attackStartTime = Time.realtimeSinceStartup;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other is IVulnrable)
        {
            IVulnrable enemy = other as IVulnrable;
            enemy.takeDamage();
        }

    }
}
