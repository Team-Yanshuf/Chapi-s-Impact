using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilMonster : MonoBehaviour
{
    WormChasePlayer movementM;
    AnimationStateHandler animationM;
    [SerializeField] GameObject target;
    EnemyCollision collisionM;
    // Start is called before the first frame update
    void Awake()
    {
        collisionM = GetComponent<EnemyCollision>();
        movementM = GetComponent<WormChasePlayer>();
        animationM = GetComponent<AnimationStateHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getTargetPosition()
    {
        if (isPlayer())
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

    bool isPlayer()
    {
        return target != null;
    }

    public bool isHurt()
    {
        return collisionM.isHurt();
    }
}
