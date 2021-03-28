using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanAnimation : MonoBehaviour
{
    Trashcan trashM;
    Animator animator;
    SpriteRenderer renderer;

    [SerializeField] bool enableAnimation;

    void Start()
    {
        trashM = GetComponent<Trashcan>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        trashM.addJumpEventListener(haltAnimation);
        trashM.addLandEventListener(resumeAnimation);
    }

    // Update is called once per frame
    void Update()
    {
       // if (enableAnimation)
            setParameters();

        setLookDirection();

    }

    void setParameters()
	{
        animator.SetBool("Attacking", trashM.isAttacking());
        //animator.SetBool("isMoving", trashM.isMoving());
	}


    void setLookDirection()
    {
        float direction = trashM.getLookDirection();

        if (direction > 0)
            renderer.flipX = false;

        else if (direction < 0)
            renderer.flipX = true;

    }

    void haltAnimation()
    { 
        animator.speed = 0;
    }

    void resumeAnimation()
    {
        animator.speed = 1;
    }

}
