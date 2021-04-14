using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanHealth : MonoBehaviour
{
    Trashcan trashM;
    EnemyHealthbar bar;
    float hp;
    void Start()
    {
        trashM = GetComponent<Trashcan>();
        hp = trashM.getMaxHP();
        bar = GetComponentInChildren<EnemyHealthbar>();
        bar.setCurrentAndMaxHealth(hp);
    }

    // Update is called once per frame
    void Update()
    {
        checkIfAlive();
        bar.setCurrentHP(hp);
    }

    public void reductHP(float damage = 0)
    {
        hp -= damage;
    }


    void checkIfAlive()
    {
        if (hp <= 0)
        {
            GameManagerEvents.onEnemyDefeated();
            trashM.die();
        }
    }
}
