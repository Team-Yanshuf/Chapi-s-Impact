using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyLeaf : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IVulnrable enemy = collision.gameObject.GetComponent<IVulnrable>();
            Vector3 pushback = new Vector3(transform.localScale.x, 0, 0);
            enemy?.takeDamage(Vector3.zero, 10);
        }
    }
}
