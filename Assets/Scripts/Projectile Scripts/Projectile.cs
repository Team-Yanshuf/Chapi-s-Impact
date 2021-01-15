using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;

     Vector3 direction;
 
    Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        speed = 10f;
    }


    // Update is called once per frame
    void Update()
    {
        move();
    }
    public void fireWithRotation(Quaternion rot,Vector3 direction)
    {
        if (!rb)
        {
            Debug.Log("No Rigidbody reference in projectile!");
            return;
        }

        this.direction = direction;
        transform.rotation = rot;
    }


    void move()
    {
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }
}
