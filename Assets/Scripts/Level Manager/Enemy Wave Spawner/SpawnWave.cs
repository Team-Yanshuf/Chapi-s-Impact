using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct SpawnWaveInfo
{
    public bool isDone { get; set; }
    public int remainingEnemies { get; set; }
    public int maxEnemies { get; set; }

    public SpawnWaveInfo(bool isDone, int maxEnemies, int remainingEnemies)
	{
        this.isDone = isDone;
        this.remainingEnemies = remainingEnemies;
        this.maxEnemies = maxEnemies;
	}
}
public class SpawnWave : MonoBehaviour
{
    List<GameObject> enemies;
    SpawnWaveInfo waveInfo;
    bool initDone = false;

    void Update()
    {
        if (initDone)
		{
            checkIfWaveIsDone();
        }

    }

    public void initSelf()
	{
        enemies = new List<GameObject>();

        foreach (Transform child in transform)
        {
            enemies.Add(child.gameObject);
        }

        foreach(GameObject enemy in enemies)
		{
            enemy.GetComponent<EnemySpawnPoint>().initSelf();
		}

        waveInfo = new SpawnWaveInfo(false, enemies.Count, enemies.Count);

        initDone = true;
	}

    public void checkIfWaveIsDone()
	{
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<EnemySpawnPoint>().GetSpawnPointInfo().isAlive == true)
			{
                waveInfo.isDone = false;
                return;
            }

		}
        waveInfo.isDone = true;
	}

    public bool isWaveDone() => waveInfo.isDone;
}
