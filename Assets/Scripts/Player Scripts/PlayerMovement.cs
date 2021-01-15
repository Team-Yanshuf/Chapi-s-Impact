using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Component References.
    Player playerM;
    Rigidbody rb;
    SpriteRenderer renderer;
    Vector3 movement;
    [SerializeField] float groundRotation;

    float horizontal, vertical;

    [SerializeField] int speed;
    void Start()
    { 
        playerM = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        move();

    }


    void move()
    {
        playerM.getMovementAxes(ref horizontal, ref vertical);
        movement = new Vector3(horizontal, vertical,0);
        Quaternion rotation = Quaternion.Euler(groundRotation, 0, 0);
        movement = rotation * movement;
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }

    //TODO:change the sorting layer dynamically according to player position.
    void changeSortingLayer()
    {
    }


    public bool isMoving()
    {
        return movement.magnitude != 0;
    }



}
