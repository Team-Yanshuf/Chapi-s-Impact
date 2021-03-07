using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilMonster : MonoBehaviour
{
    [SerializeField] GameObject target;

    OilMonsterAnimation animationM;
    OilMonsterSounds soundM;
    WormChasePlayer movementM;
    EnemyAgro agroM;

    EnemyCollision collisionM;
 
    void Awake()
    {
        collisionM = GetComponent<EnemyCollision>();
        movementM = GetComponent<WormChasePlayer>();
        animationM = GetComponent<OilMonsterAnimation>();
        agroM = GetComponent<EnemyAgro>();
        soundM = GetComponent<OilMonsterSounds>();
    }

    public Vector3 getTargetPosition()
    {
        if (target)
            return target.transform.position;
        return transform.position;
    }

    public bool isCrawling()
    {
        if (!animationM)
        {
            Debug.Log("No animation handler ");
            return false;
        }

         return animationM.isInActiveCrawl();
    }
    public bool isHurt() => collisionM.isHurt();
    public bool isAgroed() => agroM.isAgroed();

    public void die()
	{
        soundM.playDie();
        Destroy(this.gameObject);
	}
}