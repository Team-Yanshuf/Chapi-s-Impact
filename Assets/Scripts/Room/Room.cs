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
		this.finishedLoading = containerInfo.FinishedLoading;

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
	Vector3[] spawnPositions;

	BridgePositioning bridgeM;
	GameObject[] roomAdjacencyList;
	RoomEvents events;
	FogManager fogM;
	NatureSpawner natureM;
	EnemyWaveManager waveM;
	LightingManager lightingM;

	bool roomCompleted;
	bool isInstantiated;
	bool[] adjecencyList;
	public bool isActive;

	float previousLightIntensity;

	public void init(GameObject[] list, Light2D lightSource)
	{
		previousLightIntensity = 0.1f;

		events = GetComponent<RoomEvents>();
		events.initEvents();
		events.roomCleared.AddListener(decideOpenBridges);

		bridgeM = GetComponent<BridgePositioning>();
        this.roomAdjacencyList=list;
        bridgeM.init(list);

		waveM = GetComponent<EnemyWaveManager>();
		waveM.InitSelf();

		fogM = GetComponent<FogManager>();
		fogM.initSelf();


		natureM = GetComponent<NatureSpawner>();
		natureM.initSelf();

		lightingM = GetComponent<LightingManager>();
		lightingM.initSelf(lightSource);

		roomCompleted = false;
		isInstantiated = false;
	}

	public void decideOpenBridges()
	{
		bridgeM.openBridges();
	}
	public RoomInfo getRoomInfo() => new RoomInfo(fogM.getPollutionInfo(),waveM.GetSpawnWaveManagerInfo(),isActive);

	public void invokeTreePlantedEvent()
	{
		events.treePlanted.Invoke();
	}

	public void setIsActive(bool val)
	{
		this.isActive = val;
	}

	internal void resetLight()
	{
		lightingM.resetLightingToRoomCurrent(previousLightIntensity);
	}

	internal void InstantiateEnemiesInRoom()
	{
		if(!waveM.GetSpawnWaveManagerInfo().AreAllWavesDefeatedInRoom)
		{
			waveM.initSelfsub(events);
			isInstantiated = true;
		}
	}

	public void exitRoom()
	{
		previousLightIntensity = lightingM.getIntensity();
		//events.removeAllListeners();
	}

	public void enterRoom()
	{
		InstantiateEnemiesInRoom();
		//attachLighting();
		resetLight();

	}

	public override bool Equals(object other)
	{
		Room otherRoom = (Room)other;
		string current = gameObject.name.Replace("(Clone)", "");
		return current.Equals(otherRoom.gameObject.name);
	}
}
