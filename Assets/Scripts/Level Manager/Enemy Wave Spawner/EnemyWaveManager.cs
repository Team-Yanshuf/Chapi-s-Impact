using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SpawnwaveManagerInfo
{
    public int TotalNumberOfWaves { get; set; }
    public int RemainingNumberOfWaves { get; set; }
    public bool AreAllWavesDefeatedInRoom { get; set; }

    public SpawnwaveManagerInfo(int total, int remainingWaves)
	{
        this.TotalNumberOfWaves = total;
        this.RemainingNumberOfWaves = remainingWaves;
        AreAllWavesDefeatedInRoom = RemainingNumberOfWaves <= 0;
	}
}
public class EnemyWaveManager : MonoBehaviour
{
    int randomizedNumberOfSpawnWaves;
    int currentWaveIndex;
    int totalNumberOfWaves;
    int remainingNumberOfWaves;
    SpawnWave currentWave;
    List<SpawnWave> waves;

    public RoomEvents roomEvents;

    bool ready = false;
    void Update()
    {
        if (ready)
        {
            if (currentWave.isWaveDone() && currentWaveIndex< totalNumberOfWaves)
			{
                ActivateNextWave();
			}
        }
    }

    public void initSelfsub(RoomEvents events)
    {
        this.roomEvents = events;
        InitSelf();
        ActivateNextWave();
    }

	public void InitSelf()
    {
        waves = new List<SpawnWave>(GetComponentsInChildren<SpawnWave>());
        randomizedNumberOfSpawnWaves = Random.Range(1, waves.Count + 1);

        
        for (int i = 0; i < totalNumberOfWaves - randomizedNumberOfSpawnWaves; i++)
        {
            waves.RemoveAt(Random.Range(1, waves.Count));
        }
        totalNumberOfWaves = waves.Count;
        remainingNumberOfWaves = waves.Count + 1;
        currentWaveIndex = -1;
       
    }

	public void ActivateNextWave()
    {
        currentWaveIndex++;
        remainingNumberOfWaves--;

		if (totalNumberOfWaves <= currentWaveIndex)
		{
            roomEvents.roomCleared.Invoke();
            remainingNumberOfWaves = 0;
            
            print("No Waves.");
            return;
        }

        currentWave = waves[currentWaveIndex];
        currentWave.initSelf(roomEvents);

        ready = true;
    }

	public SpawnwaveManagerInfo GetSpawnWaveManagerInfo()
	{
        return new SpawnwaveManagerInfo(totalNumberOfWaves, remainingNumberOfWaves);
	}
}