using System.Collections.Generic;
using UnityEngine;

    public struct SpawnwaveManagerInfo
{
    public int numberOfWaves { get; set; }
    public int numberOfEnemiesInCurrentWave { get; set; }
    
}
public class EnemyWaveManager : MonoBehaviour
{

    int randomizedNumberOfSpawnWaves;
    int currentWaveIndex;
    SpawnWave currentWave;
    List<SpawnWave> waves;

    bool canUpdateRun = false;
    void Update()
    {
        if (canUpdateRun)
        {
            if (currentWave.isWaveDone() && waves.Count>1)
			{
                activateNextWave();
			}
        }

    }

    public void initSelf()
    {
        initWaves();
        activateNextWave();
    }

    void initWaves()
    {

        waves = new List<SpawnWave>(GetComponentsInChildren<SpawnWave>());
        randomizedNumberOfSpawnWaves = Random.Range(0, waves.Count + 1);
        int count = waves.Count;
        for (int i = 0; i < count - randomizedNumberOfSpawnWaves; i++)
        {
            waves.RemoveAt(Random.Range(0, waves.Count));
        }
        canUpdateRun = true;
        print(waves.Count);
    }

    public void activateNextWave()
    {
        currentWave = waves[0];
        currentWave.initSelf();
    }
}