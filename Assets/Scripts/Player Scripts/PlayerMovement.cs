using System.Collections;
using UnityEngine;

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

    float direction;

    float horizontal, vertical;
    bool isDashing;

    void Start()
    { 
        playerM = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        isDashing = false;
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        setMovementVector();

        if (!playerM.isPlanting())
        move();

        handleWeaponDirection();
    }

    private void setMovementVector()
    {
        if (playerM.isPlanting())
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
            isDashing = true;
            teleDash();
        }

        else
        {
            isDashing = false;
            rb.MovePosition(transform.position + movement * speed *  Time.deltaTime);
        }
    }

    public bool isMoving()
    {
        return movement.magnitude != 0;
    }

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
        for (int i=0; i<5; i++)
        { 
            rb.MovePosition(transform.position + movement * dashSpeed * Time.deltaTime);
            yield return null;

        }

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
//TODO:change the sorting layer dynamically according to player position.