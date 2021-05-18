using System;
using UnityEngine;

public class Room : MonoBehaviour
{

    BridgePositioning bridgeM;
    bool[] adjecencyList;
	GameObject[] roomAdjacencyList;
    Vector3[] spawnPositions;

	internal Vector3 getSpawnPosition()
	{
		throw new NotImplementedException();
	}

	public void init(GameObject[] list)
	{
        bridgeM = GetComponent<BridgePositioning>();
        this.roomAdjacencyList=list;
        bridgeM.init(list);
	}
	internal void setAdjecencyList(bool[] list)
	{
        this.adjecencyList = list;
	}

    public void setRoomAdjacencyList(GameObject[] list)
	{
        this.roomAdjacencyList = list;
	}
}
