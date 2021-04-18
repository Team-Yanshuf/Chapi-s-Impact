using System;
using System.Collections;
using UnityEngine;


struct PlayerMovementInfo
{

}
public class PlayerMovement : MonoBehaviour
{
    //Component References.
    Player playerM;
    Rigidbody rb;
    Vector3 movement;
    [SerializeField] float groundRotation;
    [SerializeField] float speed;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashLength;

    float direction, horizontal, vertical;
    bool isDashing;

    void Start()
    { 
        playerM = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        isDashing = false;
        direction = 1;
    }
    void Update()
    {
        setMovementVector();

        if (!playerM.isPlanting() && !playerM.isAttacking())
        move();

        handleWeaponDirection();
    }
    private void setMovementVector()
    {
        if (playerM.isPlanting() || playerM.isAttacking())
		{
            movement = Vector3.zero;
            return;
		}

        playerM.getMovementAxes(ref horizontal, ref vertical);
        movement = new Vector3(horizontal, vertical, 0);
        Quaternion rotation = Quaternion.Euler(groundRotation, 0, 0);
        movement = rotation * movement;
    }
    void move()
    {
         //if (playerM.dashPressed())
         if (Input.GetKeyDown(KeyCode.C))
        {
            //isDashing = true;
            teleDash();
        }

        else
        {
            //isDashing = false;
            rb.MovePosition(transform.position + movement * speed *  Time.deltaTime);
        }
    }
	internal void applyPushback(Vector3 pushback)
	{
        rb.AddForce(pushback, ForceMode.Impulse);
	}
	public bool isMoving()
    {
        return movement.magnitude != 0;
    }
    public Vector3 getActualMovement() => movement;
    public bool isDash()
    {
        return isDashing;
    }
    void teleDash()
    {
        StartCoroutine(dash());

    }
    IEnumerator dash()
    {
        if (movement.magnitude == 0)
            yield break;


        isDashing = true;
        for (int i=0; i<3; i++)
        { 
            rb.MovePosition(transform.position + movement * dashSpeed);
            yield return null;
        }
        isDashing = false;

    }
    void handleWeaponDirection()
	{
        if (movement.x != 0)
        {
            Transform[] weaponTransform = GetComponentsInChildren<Transform>();
            weaponTransform[1].localScale = new Vector3(Mathf.Sign(movement.x), 1, 1);
        }
	}
    public float getChapiDirection()
	{
        if (movement.x != 0)
        {
            direction = movement.x;
            return sign(movement.x);

        }
        else
		{
            return sign(direction);
        }
	}
    int sign(float num)
	{
        if (num == 0)
            return 0;

        if (num > 0)
            return 1;
        else
            return -1;
	}
}