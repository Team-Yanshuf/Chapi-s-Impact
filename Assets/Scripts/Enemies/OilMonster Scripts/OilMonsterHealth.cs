using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilMonsterHealth : MonoBehaviour, IHealthManager
{
    OilMonster monsterM;
    EnemyHealthbar bar;
    float currentHP;
    float maxHP;
    bool dead;

    void Start()
    {
        monsterM = GetComponent<OilMonster>();
        bar = GetComponentInChildren<EnemyHealthbar>();
        bar.initBar(currentHP);
    }

    void Update()
    {
        checkIfAlive();
        bar.setCurrentHP(currentHP);
    }

    public void initHP(float hp)
	{
        maxHP = hp;
        currentHP = maxHP;

	}


    void checkIfAlive()
    {
        if (currentHP <= 0)
        {
            GameManagerEvents.enemyDefeated?.Invoke();
            monsterM.die();
        }
    }

    public void reductHP(float hp)
	{
        this.currentHP -= hp;
	}

	public float getCurrentHP()
	{
        return currentHP;
	}

    public float getMaxHP()
	{
        return maxHP;
	}

}
