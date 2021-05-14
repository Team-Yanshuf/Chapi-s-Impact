using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{

    [SerializeField] GameObject room;
	Vector2Int coordinates;
	GameObject[,] rooms= new GameObject[5,5];
    int occupied = 5;
    void Start()
	{
		//generateRandomMap();
		//printMapLayout();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
			generateRandomMap();
	}
	private void printMapLayout()
	{
		for (int i = 0; i < rooms.GetLength(0); i++)
		{
			string str = "   ";
			for (int j = 0; j < rooms.GetLength(1); j++)
			{
				if (rooms[i, j] != null)
					str += "[X]\t";
				else
					str += "[ ]\t";
			}
			print(str);
		}
	}

	void generateRandomMap()
	{
		clearMap();

		coordinates = new Vector2Int(2, 2);
		for (int i = 0; i < 6; i++)
		{
			float offset = 1000;
			rooms[coordinates.x, coordinates.y] = Instantiate(room, new Vector3(coordinates.x * 200 + offset, coordinates.y * 200, 0), Quaternion.Euler(40,0,0));
			coordinates = chooseNonOccupiedNeighbor(coordinates);
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
        int[] fullI = { vec.x - 1, vec.x, vec.x + 1 };
		int[] neighboorI = { vec.x, vec.y };

		int[] fullJ = { vec.y - 1, vec.y, vec.y + 1 };
        int[] neighboorJ = { vec.y - 1, vec.y + 1 };
		
        int randI;
        int randJ;

        Vector2Int rand;
        do
        {
			randI = UnityEngine.Random.Range(0, 3);
			if (randI==1)
			{
				randJ = Random.Range(0, 2);
				rand = new Vector2Int(vec.x,neighboorJ[randJ]);
			}

			else
			{
				randJ = Random.Range(0, 3);
				rand = new Vector2Int(fullI[randI], vec.y);
			}
		}
        while (rand.x < 0 || rand.x >= 5 || rand.y < 0 || rand.y >= 5 || rooms[rand.x,rand.y] != null);
        return rand;
	}
}
