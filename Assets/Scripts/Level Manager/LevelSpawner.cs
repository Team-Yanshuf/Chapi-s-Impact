using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{

    [SerializeField] GameObject room;
	Vector2Int coordinates;
	GameObject[,] rooms= new GameObject[8,8];
    int occupied = 5;

	public void init()
	{
		generateRandomMap();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
	
			printMapLayout();
		}

	}
	private void printMapLayout()
	{
		for (int i = 0; i < rooms.GetLength(0); i++)
		{
			string str = "   ";
			for (int j = 0; j < rooms.GetLength(1); j++)
			{
				if (rooms[i,j] != null)
					str += "[X]\t";
				else
					str += "[ ]\t";
			}
			print(str);
		}
	}

	void generateRandomMap()
	{
		//clearMap();

		coordinates = new Vector2Int(5, 1);
		for (int i = 0; i < 5; i++)
		{
			float offset = 1000;
			rooms[coordinates.x, coordinates.y] = Instantiate(room, new Vector3(coordinates.x * 100 + offset, coordinates.y * 100+offset, 0), Quaternion.Euler(40,0,0));
			coordinates = chooseNonOccupiedNeighbor(coordinates);
		}

		for (int i=0; i<rooms.GetLength(0); i++)
		{
			for (int j=0; j<rooms.GetLength(1); j++)
			{
				if (rooms[i, j] != null)
					rooms[i, j].GetComponent<Room>().init(getAdjecencyList(i,j));
			}
		}
	}

	void clearMap()
	{
		for(int i=0; i<rooms.GetLength(0); i++)
		{
			for (int j=0; j<rooms.GetLength(1); j++)
			{
				if (rooms[i, j])
					Destroy(rooms[i, j]);
				rooms[i,j] = null;
			}
		}
	}



	Vector2Int chooseNonOccupiedNeighbor(Vector2Int vec)
	{
		bool val;

        int[] fullI = { vec.x - 1, vec.x, vec.x + 1 };
		int[] neighboorI = { vec.x-1, vec.x+1 };

		int[] fullJ = { vec.y - 1, vec.y, vec.y + 1 };
        int[] neighboorJ = { vec.y - 1, vec.y + 1 };
		
        int randI;
        int randJ;

        Vector2Int rand;
        do
        {
			val = true;

			randI = Random.Range(0, 3);
			if (randI==1)
			{
				randJ = Random.Range(0, 2);
				rand = new Vector2Int(fullI[randI],neighboorJ[randJ]);
			}

			else
			{
				//randJ = Random.Range(0, 3);
				rand = new Vector2Int(fullI[randI], vec.y);
			}


			if (rand.x >= 0 && rand.x < rooms.GetLength(0) && rand.y >= 0 && rand.y < rooms.GetLength(1))

			{
				if (rooms[rand.x, rand.y] != null)
					val = false;
			}
			else
			{
				val = false;
			}
			
		}
        while  (!val);
        return rand;
	}

	bool[] getAdjecencyList(int i, int j)
	{
		bool[] list = new bool[4];

		if (i > 0 && rooms[i - 1, j] != null)
			list[0] = true;
		
		if (j > 0 && rooms[i, j - 1] != null)
			list[1] = true;

		if (i < rooms.GetLength(0) - 1 && rooms[i + 1, j] != null)
			list[2] = true;

		if (j < rooms.GetLength(1) - 1 && rooms[i, j + 1] != null)
			list[3] = true;

		return list;
	}
}
