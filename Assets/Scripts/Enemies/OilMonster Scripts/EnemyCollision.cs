using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour, IVulnrable
{
    bool hurt = false;
    OilMonster monsterM;
    [SerializeField] float hp;
    [SerializeField] int damage;

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
        hurt = true;
        hp -= damage;
            
    }

    void checkIfAlive()
    {
        if (hp<=0)
        {
            GameManagerEvents.enemyDefeated?.Invoke();
            monsterM.die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            IVulnrable player = collision.gameObject.GetComponent<IVulnrable>();
            player?.takeDamage(damage);

        }
    }


    public bool isHurt()
    {
        if (hurt)
        {
            hurt = false;
            return true;
        }

        return false;
    }

    void die()
	{
    
	}

}
