using UnityEngine;

public class TrashcanHealth : MonoBehaviour, IHealthManager
{
    Trashcan trashM;
    EnemyHealthbar bar;
    float hp;
    void Start()
    {
        trashM = GetComponent<Trashcan>();
        hp = trashM.getMaxHP();
        bar = GetComponentInChildren<EnemyHealthbar>();
        Canvas k = GetComponent < Canvas > ();
        bar?.initBar(hp);
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
            GameManagerEvents.OnEnemyDefeated();
            trashM.Die();
        }
    }

	public float getCurrentHP()
	{
        return hp;
	}

	public float getMaxHP()
	{
        return hp;
	}
}
