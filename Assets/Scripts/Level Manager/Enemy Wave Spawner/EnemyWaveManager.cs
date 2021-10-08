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
        AreAllWavesDefeatedInRoom = RemainingNumberOfWaves == 0;
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

    bool ready = false;
    void Update()
    {
        if (ready)
        {
            if (currentWave.isWaveDone() && currentWaveIndex<waveManagerInfo.TotalNumberOfWaves)
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
        ready = true;
    }

	public void activateNextWave()
    {
        currentWaveIndex++;
        if (waves.Count<=currentWaveIndex )
        {
            roomEvents.roomCleared.Invoke();
            waveManagerInfo.RemainingNumberOfWaves = 0;
            print("No waves.");
            return;
        }

        currentWave = waves[currentWaveIndex];
        currentWave.initSelf(roomEvents);
    }

    void updateWaveManagerInfo()
    {
        waveManagerInfo.RemainingNumberOfWaves = waveManagerInfo.TotalNumberOfWaves - currentWaveIndex;
        waveManagerInfo.AreAllWavesDefeatedInRoom = waveManagerInfo.RemainingNumberOfWaves == 0;
        //print("Remaining number of waves:" + waveManagerInfo.remainingNumberOfWaves);
    }

	public SpawnwaveManagerInfo GetSpawnWaveManagerInfo() => waveManagerInfo;


	//   public SpawnwaveManagerInfo GetSpawnWaveManagerInfo()
	//{
	//       int totalNumberOfWavesInRoom = waves.Count;
	//       int remainingNumberOfWavesInRoom = waves.Count - currentWaveIndex;
	//       return new SpawnwaveManagerInfo(totalNumberOfWavesInRoom, remainingNumberOfWavesInRoom);
	//}
}