using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilMonster : MonoBehaviour
{
    WormChasePlayer movementM;
    AnimationStateHandler animationM;
    [SerializeField] GameObject target;
    // Start is called before the first frame update
    void Awake()
    {
        movementM = GetComponent<WormChasePlayer>();
        animationM = GetComponent<AnimationStateHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getTargetPosition()
    {
        return target.transform.position;
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


}
