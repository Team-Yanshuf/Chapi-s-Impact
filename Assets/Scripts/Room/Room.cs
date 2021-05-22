using UnityEngine;

public struct RoomInfo
{
	public PollutionContainerInfo containerInfo;
	public bool finishedLoading;

	public RoomInfo(PollutionContainerInfo info)
	{
		this.containerInfo = info;
		this.finishedLoading = info.finishedLoading;
	}
}

public class Room : MonoBehaviour
{
	RoomInfo info;
    BridgePositioning bridgeM;
    bool[] adjecencyList;
	GameObject[] roomAdjacencyList;
    Vector3[] spawnPositions;

	FogManager fogM;
	NatureSpawner natureM;



	public void init(GameObject[] list)
	{
        bridgeM = GetComponent<BridgePositioning>();
        this.roomAdjacencyList=list;
        bridgeM.init(list);
		fogM = GetComponent<FogManager>();

		natureM = GetComponent<NatureSpawner>();
		natureM.initSelf();
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

	public RoomInfo getRoomInfo() => new RoomInfo(fogM.getPollutionInfo());
}
