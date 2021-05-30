using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public struct RoomInfo
{
	public PollutionContainerInfo containerInfo;
	public SpawnwaveManagerInfo wavesInfo;
	public bool finishedLoading;
	public bool isActive;

	public RoomInfo(PollutionContainerInfo containerInfo, SpawnwaveManagerInfo wavesInfo, bool isActive)
	{
		this.containerInfo = containerInfo;
		this.finishedLoading = containerInfo.finishedLoading;

		this.wavesInfo = wavesInfo;
		this.isActive = isActive;
	}
}

[RequireComponent(typeof(EnemyWaveManager))]
[RequireComponent(typeof(RoomEvents))]
[RequireComponent(typeof(NatureSpawner))]
[RequireComponent(typeof(FogManager))]
[RequireComponent(typeof(BridgePositioning))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(LightingManager))]
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
	LightingManager lightingM;

	bool roomCompleted;

	public bool isActive;
	internal bool isInstantiated;

	public void init(GameObject[] list, Light2D lightSource)
	{
		events = GetComponent<RoomEvents>();
		events.initEvents();
		events.roomCleared.AddListener(decideOpenBridges);
		events.roomEntered.AddListener(instantiateEnemies);
		events.roomEntered.AddListener(resetLight);
		events.roomEntered.AddListener(attachLighting);

		bridgeM = GetComponent<BridgePositioning>();
        this.roomAdjacencyList=list;
        bridgeM.init(list);

		fogM = GetComponent<FogManager>();
		fogM.initSelf();

		natureM = GetComponent<NatureSpawner>();
		natureM.initSelf();

		waveM = GetComponent<EnemyWaveManager>();
		//waveM.initSelf(events);

		lightingM = GetComponent<LightingManager>();
		lightingM.initSelf(lightSource);
		//attachLighting();



		roomCompleted = false;
		isInstantiated = false;
	}
	internal void setAdjecencyList(bool[] list)
	{
        this.adjecencyList = list;
	}

    public void setRoomAdjacencyList(GameObject[] list)
	{
        this.roomAdjacencyList = list;
	}

	public void decideOpenBridges()
	{
		bridgeM.openBridges();
	}
	public RoomInfo getRoomInfo() => new RoomInfo(fogM.getPollutionInfo(),waveM.getSpawnWaveManagerInfo(),isActive);

	public void invokeTreePlantedEvent()
	{
		events.treePlanted.Invoke();
	}

	public void setIsActive(bool val)
	{
		this.isActive = val;
	}

	internal void attachLighting()
	{
		events.treePlanted.AddListener(lightingM.adaptLightingToTreePlanted);
		events.dwindleLocalFog.AddListener(lightingM.adaptLightingToEnemyDeath);
		//try
		//{

		//}
		//catch(NullReferenceException e)
		//{
		//	print($"in room {this.name}: events is {events != null}, tree planted is {events.treePlanted != null}  ");
		//}


	}

	internal void resetLight()
	{
		lightingM.resetLighting();
	}

	internal void instantiateEnemies()
	{
		if(!waveM.getSpawnWaveManagerInfo().isCompleted)
		{
			waveM.initSelf(events);
			isInstantiated = true;
		}

	}
}
