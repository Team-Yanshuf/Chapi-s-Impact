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
    public void takeDamage(Vector3 pushback, float damage = 0)
    {
        hurt = true;
        hp -= damage;
        if (hp <= 0)
            return;

        monsterM.pushback(pushback);

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
            float sign= Mathf.Sign(collision.transform.position.x-transform.position.x);
            player?.takeDamage(transform.right*sign*10, damage);
        }
    }


    public bool isHurt()
    {
        if (hurt)
        {
            //hurt = false;
            return true;
        }

        return false;
    }

    public void setNotHurt() => hurt = false;
}
