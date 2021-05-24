﻿using System.Collections.Generic;
using UnityEngine;

public struct RoomManagerInfo
{
	public PollutionContainerInfo[] pollutionContainers { get; }
	public int initialFogCount { get; set; }
	public float remainingFogPrecentage { get; set; }
	public bool finishedLoading { get; set; }

	public RoomManagerInfo(PollutionContainerInfo[] containers)
	{
		this.pollutionContainers = containers;

		//These are Faux values.
		//They are provided so that calculateValues() can run.
		initialFogCount = 0;
		remainingFogPrecentage = 0;
		finishedLoading = true;

		//Real values are calculated here!
		calculateValues();

	}
	void calculateValues()
	{
		int currentFogAmount = 0;
		foreach (PollutionContainerInfo container in pollutionContainers)
		{
			initialFogCount += container.initialFogCount;
			currentFogAmount += container.remainingFogAmount;

			if (!container.finishedLoading)
				finishedLoading = false;

		}
		if (initialFogCount > 0)
			remainingFogPrecentage = (float)(100 * currentFogAmount / initialFogCount);
		else remainingFogPrecentage = 0;
	}






}
public class RoomsManager : MonoBehaviour
{
    [SerializeField] GameObject room;
	[SerializeField] GameObject[] rooms;
	GameObject[,] roomMatrix= new GameObject[5,5];
	List<Room> roomList = new List<Room>();
	Player player;

	public void init()
	{
		initRooms();
		initFogInRooms();

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		player.updateCurrentRoom(roomMatrix[2, 2].GetComponent<Room>());

		void initRooms()
		{
			generateRandomMap();
		}
		void generateRandomMap()
		{
			clearMap();
			//string str = "";
			Vector2Int coordinates = new Vector2Int(2, 2);

			for (int i = 1; i < 6; i++)
			{
				float offset = 200;

				roomMatrix[coordinates.x, coordinates.y] = Instantiate(rooms[Random.Range(0,rooms.Length)], new Vector3((coordinates.x * 250) + offset, coordinates.y * 250, 0), Quaternion.Euler(40, 0, 0));
				roomList.Add(roomMatrix[coordinates.x, coordinates.y].GetComponent<Room>());
				coordinates = chooseNonOccupiedNeighbor(coordinates);

			}

			for (int i = 0; i < roomMatrix.GetLength(0); i++)
			{
				for (int j = 0; j < roomMatrix.GetLength(1); j++)
				{
					if (roomMatrix[i, j] != null)
						roomMatrix[i, j].GetComponent<Room>().init(getRoomAdjacencyList(i, j));
				}
			}

			for (int i = 0; i < roomMatrix.GetLength(0); i++)
			{
				for (int j = 0; j < roomMatrix.GetLength(1); j++)
				{
					if (roomMatrix[i, j] != null)
						roomMatrix[i, j].GetComponent<BridgePositioning>().initDirections();

				}
			}

		}
		void printMapLayout()
		{
			Debug.ClearDeveloperConsole();
			for (int i = 0; i < roomMatrix.GetLength(1); i++)
			{
				string str = "   ";
				for (int j = 0; j < roomMatrix.GetLength(0); j++)
				{
					if (roomMatrix[i, j] != null)
					{
						str += "[X]\t";
					}

					else
						str += "[ ]\t";
				}
				print(str);
			}
		}
		void clearMap()
		{
			for (int i = 0; i < roomMatrix.GetLength(0); i++)
			{
				for (int j = 0; j < roomMatrix.GetLength(1); j++)
				{
					if (roomMatrix[i, j])
						Destroy(roomMatrix[i, j]);
					roomMatrix[i, j] = null;
				}
			}
		}
		Vector2Int chooseNonOccupiedNeighbor(Vector2Int vec)
		{
			bool val;

			//int[] fullI = { vec.x - 1, vec.x, vec.x + 1 };
			int[] neighboorI = { vec.x - 1, vec.x + 1 };

			//int[] fullJ = { vec.y - 1, vec.y, vec.y + 1 };
			int[] neighboorJ = { vec.y - 1, vec.y + 1 };

			int randI;
			int randJ;
			Vector2Int rand;
			do
			{
				val = true;
				int r = Random.Range(0, 2);
				if (r == 0)
				{
					randI = neighboorI[Random.Range(0, 2)];
					randJ = vec.y;
					rand = new Vector2Int(randI, randJ);
				}

				else
				{
					randI = vec.x;
					randJ = neighboorJ[Random.Range(0, 2)];
					rand = new Vector2Int(randI, randJ);
				}

				if (randI >= 0 && randI < roomMatrix.GetLength(0) && randJ >= 0 && randJ < roomMatrix.GetLength(1))
				{
					if (roomMatrix[randI, randJ] != null)
						val = false;
				}
				else
				{
					val = false;
				}
			}
			while (!val);
			return rand;
		}
		GameObject[] getRoomAdjacencyList(int i, int j)
		{
			//ADJECENCY LIST IS LEFT SHIFTED!
			//INDECES ARE ADJUSTED TO FIT THE DIFFERENCE BETWEEN
			//PRINTED AND ACTUAL VERSION!

			GameObject[] list = new GameObject[4];
			if (roomMatrix[i, j] == null)
				return null;

			if (i > 0 && roomMatrix[i - 1, j] != null)
				list[1] = roomMatrix[i - 1, j];

			if (j > 0 && roomMatrix[i, j - 1] != null)
				list[2] = roomMatrix[i, j - 1];

			if (i < roomMatrix.GetLength(0) - 1 && roomMatrix[i + 1, j] != null)
				list[3] = roomMatrix[i + 1, j];

			if (j < roomMatrix.GetLength(1) - 1 && roomMatrix[i, j + 1] != null)
				list[0] = roomMatrix[i, j + 1];

			return list;
		}
	}
	void initFogInRooms()
	{
		foreach (Room room in roomList)
		{
			room.initFog();
		}
	}

	public RoomManagerInfo getRoomManagerInfo()
	{
		PollutionContainerInfo[] containers = new PollutionContainerInfo[roomList.Count];

		for(int i=0; i<containers.Length; i++)
		{
			containers[i]= roomList[i].getRoomInfo().containerInfo;
		}

		return new RoomManagerInfo(containers);
	}
}