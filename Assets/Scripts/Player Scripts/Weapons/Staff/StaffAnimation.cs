using UnityEngine;

public class StaffAnimation : MonoBehaviour
{
    PlayerInfo info;
    WeaponManager weaponM;
    Animator animator;

    float prevX;
    float prevZ;
    bool canUpdate;
    // Start is called before the first frame update
    
    public void initSelf()
	{
        animator = GetComponent<Animator>();
        canUpdate = true;
	}



    // Update is called once per frame
    void Update()
    {
        if (canUpdate)
		{
            setAnimatorParameters();
		}
    }

    void setAnimatorParameters()
	{
        animator.SetFloat("Speed", info.speed);
        animator.SetInteger("Attacking", info.attackNumber);
        animator.SetBool("IsPlanting", info.isPlanting);

        faceDirection();
	}

    void faceDirection()
	{
        Vector3 movement = info.movement;
        if (movement.magnitude != 0)
        {
            prevX = movement.x;
            prevZ = movement.z;
            animator.SetFloat("Horizontal", prevX);
            animator.SetFloat("Vertical", prevZ);
        }
    }

    public void setPlayerInfo(PlayerInfo info)
	{
        this.info = info;
	}
}
