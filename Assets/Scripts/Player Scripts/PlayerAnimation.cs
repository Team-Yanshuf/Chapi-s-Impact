using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator m_Animator;
    Player playerM;
    Vector3 movement;

    float prevX=0, prevZ = 0;


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        playerM = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        ChapisAnimation();
    }

    void ChapisAnimation()
    {
        playerM.getMovementAxes(ref movement.x, ref movement.z);

        m_Animator.SetFloat("Speed", movement.magnitude);

        if (movement.magnitude!=0)
        {
            m_Animator.SetFloat("Vertical", movement.z);
            m_Animator.SetFloat("Horizontal", movement.x);
            prevX = movement.x;
            prevZ = movement.z;
        }
        else
        {
            m_Animator.SetFloat("Vertical", prevZ);
            m_Animator.SetFloat("Horizontal", prevX);
        }


        m_Animator.SetBool("IsDashing", playerM.isDashing());
        m_Animator.SetInteger("Attacking", playerM.comboCount());
    }
}
