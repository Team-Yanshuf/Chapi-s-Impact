using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour, IVulnrable
{
    OilMonster monsterM;
    [SerializeField] float hp;

    // Start is called before the first frame update
    void Start()
    {
        monsterM= GetComponent<OilMonster>();       
    }

    private void Update()
    {
        checkIfAlive();
    }
    public void takeDamage(float damage)
    {
        hp -= damage;
            
    }

    void checkIfAlive()
    {
        if (hp<=0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            IVulnrable player = collision.gameObject.GetComponent<IVulnrable>();
            Debug.Log("Attacking player");
            player?.takeDamage(15);
        }
    }

}
