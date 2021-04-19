using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct SpawnWaveInfo
{
    public bool isDone;

}
public class SpawnWave : MonoBehaviour
{
    
    List<GameObject> enemies;
    bool waveDone = false;

    // Update is called once per frame
    void Update()
    {
        
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
	}

    public void checkIfWaveIsDone()
	{
        foreach (GameObject enemy in enemies)
		{
            if (enemy.GetComponent<EnemySpawnPoint>().GetSpawnPointInfo().isAlive == true)
                waveDone= false;

		}

        waveDone = true;
	}

    public bool isWaveDone() => waveDone;


}
