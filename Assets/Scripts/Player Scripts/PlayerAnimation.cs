using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    Player playerM;
    Vector3 movement;
    GameObject aura;

    //Will be in charge of storing the last faced direction.
    float prevX, prevZ;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerM = GetComponent<Player>();
        aura = transform.Find("Aura").gameObject;
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
		movement = playerM.getActualMovement();// (ref movement.x, ref movement.z);

		animator.SetFloat("Speed", movement.magnitude);


		/* 
		 * This setup does not take planting into account.
		 * meaning the planting while moving diagonally results
		 * in planting in the wrong direction.
		 * Fix this!
		 */
		altLookDirection();

		animator.SetBool("IsDashing", playerM.isDashing());
		animator.SetInteger("Attacking", playerM.comboCount());
		animator.SetBool("IsPlanting", playerM.isPlanting());
		animator.SetBool("IsHurt", playerM.isHurt());

		manageAura();
	}

	private void setLookDirection()
	{
		if (movement.x != 0)
		{
			animator.SetFloat("Horizontal", movement.x);
			prevX = movement.x;
		}
		else
			animator.SetFloat("Horizontal", prevX);

		if (movement.z != 0)
		{
			animator.SetFloat("Vertical", movement.z);
			prevZ = movement.z;

			if (movement.x == 0)
				animator.SetFloat("Horizontal", 0f);
		}

		else
			animator.SetFloat("Vertical", prevZ);
	}


	void altLookDirection()
	{
		if (movement.magnitude!=0)
		{
			prevX = movement.x;
			prevZ = movement.z;
			animator.SetFloat("Horizontal", prevX);
			animator.SetFloat("Vertical", prevZ);
		}
		//if (movement.x>movement.z)
		//{
		//	prevX = movement.x;
		//	animator.SetFloat("Horizontal", prevX);
		//}

		//else if (movement.x<=movement.z)
		//{
		//	prevZ = movement.y;
		//	animator.SetFloat("Vertical", prevZ);
		//}
	}

	void manageAura()
	{
        if (playerM.getHowManyTreesCanPlant() > 0)
            aura.SetActive(true);
        else
            aura.SetActive(false);
	}
}
