using System.Collections.Generic;
using UnityEngine;

public struct SpawnwaveManagerInfo
{
    public int totalNumberOfWaves { get; set; }
    public int remainingNumberOfWaves { get; set; }

    public SpawnwaveManagerInfo(int total, int remainingWaves)
	{
        this.totalNumberOfWaves = total;
        this.remainingNumberOfWaves = remainingWaves;
	}


}
public class EnemyWaveManager : MonoBehaviour
{
    SpawnwaveManagerInfo waveManagerInfo;
    int randomizedNumberOfSpawnWaves;
    int currentWaveIndex;
    SpawnWave currentWave;
    List<SpawnWave> waves;

    public RoomEvents roomEvents;

    bool canUpdateRun = false;
    void Update()
    {
        if (canUpdateRun)
        {
            if (currentWave.isWaveDone() && currentWaveIndex<waveManagerInfo.totalNumberOfWaves)
			{
                activateNextWave();
			}

            updateWaveManagerInfo();
        }

    }

    public void initSelf(RoomEvents events)
    {
        this.roomEvents = events;
        initWaves();
        activateNextWave();
        waveManagerInfo = new SpawnwaveManagerInfo(waves.Count, waves.Count);
    }

	internal void setRoomEvents(RoomEvents events)
	{
        this.roomEvents = events;
	}

	void initWaves()
    {
        waves = new List<SpawnWave>(GetComponentsInChildren<SpawnWave>());
        randomizedNumberOfSpawnWaves = Random.Range(1, waves.Count + 1);
        int count = waves.Count;
        
        for (int i = 0; i < count - randomizedNumberOfSpawnWaves; i++)
        {
            waves.RemoveAt(Random.Range(1, waves.Count));
        }

        currentWaveIndex = -1;
        canUpdateRun = true;
    }

	public void activateNextWave()
    {
        currentWaveIndex++;
        if (waves.Count<=currentWaveIndex )
        {
            print("No waves.");
            return;
        }

        currentWave = waves[currentWaveIndex];
        currentWave.initSelf(roomEvents);
    }

    void updateWaveManagerInfo() => waveManagerInfo.remainingNumberOfWaves = waveManagerInfo.totalNumberOfWaves - currentWaveIndex;

    public SpawnwaveManagerInfo getSpawnWaveManagerInfo() => waveManagerInfo;

}