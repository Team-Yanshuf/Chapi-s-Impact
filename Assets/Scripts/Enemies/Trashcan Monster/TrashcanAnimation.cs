using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanAnimation : MonoBehaviour
{
    Trashcan trashM;
    Animator animator;

    [SerializeField] bool enableAnimation;

    void Start()
    {
        trashM = GetComponent<Trashcan>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enableAnimation)
            setParameters();
        invokeJumpEvent();

    }

    void setParameters()
	{
        animator.SetBool("IsAttacking", trashM.isAttacking());
        animator.SetBool("isMoving", trashM.isMoving());
	}

    void invokeJumpEvent()
	{

        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        float normalized = state.normalizedTime % 1;
        if (state.IsName("TrashJump"))
        {
            if (normalized>(14f / 39f) && normalized< (16f/39f) )
			{
                TrashcanEvents.onJump();
            }

		}
	}

}
