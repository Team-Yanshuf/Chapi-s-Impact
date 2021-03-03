using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    Player playerM;
    Vector3 movement;

    //Will be in charge of storing the last faced direction.
    float prevX, prevZ;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerM = GetComponent<Player>();
        prevZ = 0;
        prevX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ChapisAnimation();
    }

    void ChapisAnimation()
    {
        playerM.getMovementAxes(ref movement.x, ref movement.z);

        animator.SetFloat("Speed", movement.magnitude);

        if (movement.x!=0)
        {
            animator.SetFloat("Horizontal", movement.x);

            prevX = movement.x;

        }
        else
            animator.SetFloat("Horizontal", prevX);
        
        if (movement.z!=0)
        {
            animator.SetFloat("Vertical", movement.z);
            prevZ = movement.z;
        }

        else
            animator.SetFloat("Vertical", prevZ);

        animator.SetBool("IsDashing", playerM.isDashing());
        animator.SetInteger("Attacking", playerM.comboCount());
        animator.SetBool("IsPlanting", playerM.isPlanting());
    }
}
