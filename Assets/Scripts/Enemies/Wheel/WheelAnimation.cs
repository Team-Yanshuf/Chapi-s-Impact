using UnityEngine;

public class WheelAnimation : MonoBehaviour
{
    Wheel wheelM;
    Animator animator;

	bool isReady;

	public void InitSelf()
	{
        animator = GetComponent<Animator>();
        wheelM = GetComponent<Wheel>();
        isReady = true;
    }


    void Update()
    {
        if (isReady)
		{
            updateAnimations();
            WheelStatesInfo info = wheelM.GetWheelStatesInfo();
            if (info.Idle || info.Starting)
            {
                setLookDirection();
            }
        }
    }

    private void updateAnimations()
	{
        WheelStatesInfo info = wheelM.GetWheelStatesInfo();
        animator.SetBool("IsPassedOut", info.Paralyzed);
		animator.SetBool("IsIdle", info.Idle);

		if (wheelM.GetWheelStatesInfo().Sprinting)
		{
            //0.01 is an arbitrarily low threshold.
			if (wheelM.GetWheelMovementInfo().Decelerating && wheelM.GetWheelMovementInfo().VelocityVector.magnitude < 0.01f)
			{
				animator.SetBool("IsIdle", true);
			}
		}
	}

	private void setLookDirection()
	{
        Vector3 movementDirection = (wheelM.GetTarget().transform.position - transform.position).normalized;
        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.z);
    }

}