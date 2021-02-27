using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    [SerializeField] float damage;
    float instantiateTime;
     Vector3 direction;
 
    Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        instantiateTime= Time.realtimeSinceStartup;
    }


    // Update is called once per frame
    void Update()
    {
        move();
        lifeTimer();    
    }
    public void fireWithRotation(Quaternion rot,Vector3 direction)
    {
        if (!rb)
        {
            return;
        }

        this.direction = direction;
        transform.rotation = rot;
    }

    void lifeTimer()
    {
        float time = Time.realtimeSinceStartup;
        if (instantiateTime+ lifeTime < time)
        {
            Destroy(this.gameObject);
        }
    }


    void move()
    {
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);

    }


    private void OnCollisionEnter(Collision collision)
    { 
        IVulnrable vuln = collision.gameObject.GetComponent<IVulnrable>();
        if(vuln!=null)
        {
            IVulnrable other = collision as IVulnrable;
            vuln.takeDamage(damage);
        }
        Destroy(this.gameObject);
    }



    
}
