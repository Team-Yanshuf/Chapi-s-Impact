using UnityEngine;


public enum EnemyType
{
    OIL_MONSTER,
    TRASHCAN,
    NONE
}

public struct SpawnPointInfo
{
    public EnemyType enemy {get;}
    public bool isAlive { get; set; }

    public SpawnPointInfo (EnemyType enemy, bool isAlive)
	{
        this.enemy = enemy;
        this.isAlive = isAlive;
	}
}

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] EnemyType enemy;
    GameObject enemyToSpawn;

    SpawnPointInfo pointInfo;

    bool canUpdateRun = false;
    RoomEvents events;

    void Update()
    {
        if (canUpdateRun)
		{
            updateInfo();
		}
    }

    GameObject chooseEnemyBasedOnSelection()
	{
        switch (enemy)
		{
            case EnemyType.OIL_MONSTER:
				{
                    return (GameObject) Instantiate(Resources.Load("Enemies/Oil Monster"),transform.position, Quaternion.identity);
				}

            case EnemyType.TRASHCAN:
				{
                    return (GameObject)Instantiate(Resources.Load("Enemies/TrashEnemy"),transform.position,Quaternion.identity);
				}

            case EnemyType.NONE:
				{
                    //No enemy chosen.
                    break;
				}
		}

        return null;
	}

    void spawnSelf(RoomEvents roomEvents)
	{
        enemyToSpawn= chooseEnemyBasedOnSelection();
        enemyToSpawn.transform.parent = this.transform;
        IEnemy enemy = enemyToSpawn.GetComponent<IEnemy>();
        enemy.setRoomEvents(roomEvents);
	}

    public void initSelf(RoomEvents roomEvents)
	{
        pointInfo = new SpawnPointInfo(enemy, true);
        spawnSelf(roomEvents);
        canUpdateRun = true;
	}

    void updateInfo()
	{
        pointInfo.isAlive = (enemyToSpawn != null);
	}

    public SpawnPointInfo GetSpawnPointInfo() => pointInfo;



}
