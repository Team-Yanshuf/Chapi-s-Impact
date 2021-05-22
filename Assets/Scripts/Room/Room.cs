﻿using UnityEngine;

public struct RoomInfo
{
	public PollutionContainerInfo containerInfo;
	public SpawnwaveManagerInfo wavesInfo;
	public bool finishedLoading;

	public RoomInfo(PollutionContainerInfo containerInfo, SpawnwaveManagerInfo wavesInfo)
	{
		this.containerInfo = containerInfo;
		this.finishedLoading = containerInfo.finishedLoading;

		this.wavesInfo = wavesInfo;
	}
}

public class Room : MonoBehaviour
{
	RoomInfo info;
    BridgePositioning bridgeM;
    bool[] adjecencyList;
	GameObject[] roomAdjacencyList;
    Vector3[] spawnPositions;

	RoomEvents events;

	FogManager fogM;
	NatureSpawner natureM;
	EnemyWaveManager waveM;



	public void init(GameObject[] list)
	{
		events = GetComponent<RoomEvents>();
		events.initEvents();
        bridgeM = GetComponent<BridgePositioning>();
        this.roomAdjacencyList=list;
        bridgeM.init(list);
		fogM = GetComponent<FogManager>();

		natureM = GetComponent<NatureSpawner>();
		natureM.initSelf();

		waveM = GetComponent<EnemyWaveManager>();
		waveM.initSelf();

	
	}
	internal void setAdjecencyList(bool[] list)
	{
        this.adjecencyList = list;
	}

    public void setRoomAdjacencyList(GameObject[] list)
	{
        this.roomAdjacencyList = list;
	}

	public void initFog()
	{
		fogM.initSelf();
		fogM.initFog();
	}

	public RoomInfo getRoomInfo() => new RoomInfo(fogM.getPollutionInfo(),waveM.getSpawnWaveManagerInfo());

	public void invokeTreePlantedEvent()
	{
		events.treePlanted.Invoke();
	}
}
