using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] GameObject room;
	Vector2Int coordinates;
	GameObject[,] rooms= new GameObject[5,5];
	//test.
	public void init()
	{
		generateRandomMap();
		printMapLayout();
	}

	void generateRandomMap()
	{
		clearMap();
		string str = "";
		coordinates = new Vector2Int(2,2);
		
		for (int i = 1; i < 6; i++)
		{
			float offset = 200;
			rooms[coordinates.x, coordinates.y] = Instantiate(room, new Vector3((coordinates.x*100)+offset,0, coordinates.y * 100),Quaternion.Euler(40,0,0));
			coordinates = chooseNonOccupiedNeighbor(coordinates);

		}

		for (int i = 0; i < rooms.GetLength(0); i++)
		{
			for (int j = 0; j < rooms.GetLength(1); j++)
			{
				if (rooms[i, j] != null)
					rooms[i, j].GetComponent<Room>().init(getRoomAdjacencyList(i, j));
			}
		}

		for (int i = 0; i < rooms.GetLength(0); i++)
		{
			for (int j = 0; j < rooms.GetLength(1); j++)
			{
				if (rooms[i, j] != null)
					rooms[i, j].GetComponent<BridgePositioning>().initDirections();

			}
		}

	}
	private void printMapLayout()
	{
		Debug.ClearDeveloperConsole();
		for (int i = 0; i < rooms.GetLength(1); i++)
		{
			string str = "   ";
			for (int j = 0; j < rooms.GetLength(0); j++)
			{
				if (rooms[i,j] != null)
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

        //int[] fullI = { vec.x - 1, vec.x, vec.x + 1 };
		int[] neighboorI = { vec.x-1, vec.x+1 };

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

			if (randI >= 0 && randI < rooms.GetLength(0) && randJ >= 0 && randJ < rooms.GetLength(1))
			{
				if (rooms[randI, randJ] != null)
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
		if (rooms[i, j] == null)
			return null;

		if (i > 0 && rooms[i - 1, j] != null)
			list[1] = rooms[i-1,j];

		if (j > 0 && rooms[i, j - 1] != null)
			list[2] = rooms[i,j-1];

		if (i < rooms.GetLength(0) - 1 && rooms[i + 1, j] != null)
			list[3] = rooms[i+1,j];

		if (j < rooms.GetLength(1) - 1 && rooms[i, j + 1] != null)
			list[0] = rooms[i,j+1];

		return list;
	}
}
