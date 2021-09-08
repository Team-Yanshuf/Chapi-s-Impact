using UnityEngine;

public class WheelAnimation : MonoBehaviour
{
    Wheel wheelM;
    Animator animator;

    bool isReady = false;
    bool isIdle;
    bool isStarting;
    bool isSprinting = false;
    bool isHittingAWall;
    bool isPassedOut;

    public void InitSelf()
	{
        animator = GetComponent<Animator>();
        wheelM = GetComponent<Wheel>();

        wheelM.GetWheelEvents().wheelCollidedWithWall.AddListener(OnHittingAWall);
        wheelM.GetWheelEvents().wheelIdle.AddListener(OnPassOutAnimationEnds);
        wheelM.GetWheelEvents().wheelStarted.AddListener(OnIdleAnimationEnd);
        isReady = true;
    }


    void Update()
    {
        updateAnimations();
        if (isIdle)
		{
            setLookDirection();
		}
    }

    private void updateAnimations()
	{
        animator.SetBool("IsPassedOut", isPassedOut);
	}

    public void OnIdleAnimationEnd()
	{
        isIdle = false;
        isStarting = true;
	}

    public void OnHittingAWall()
	{
        if (wheelM.GetWheelMovementInfo().MovementVector.magnitude > 0)
		{
            isSprinting = false;
            isPassedOut = true;
            updateAnimations();
        }
	}

    public void OnPassOutAnimationEnds()
	{
        isPassedOut = false;
        isIdle = true;
        updateAnimations();
	}

    public void OnStarterAnimationEnd()
	{
        isSprinting = true;
	}

    private void setLookDirection()
	{
        Vector3 movementDirection = (wheelM.GetTarget().transform.position - transform.position).normalized;
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.z);
    }

}