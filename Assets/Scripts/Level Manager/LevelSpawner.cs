using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
	//    [SerializeField] GameObject room;

	//    GameObject[,] rooms= new GameObject[10,10];
	//    int occupied = 5;
	//    void Start()
	//    {
	//        Vector2Int coordinates = new Vector2Int (5, 5);
	//        for (int i = 0; i<6; i++)
	//		{
	//            rooms[coordinates.x, coordinates.y] = Instantiate(room);
	//            coordinates = chooseNonOccupiedNeighbor(coordinates);
	//		}


	//        for(int i=0; i<rooms.GetLength(0); i++)
	//		{
	//            for (int j=0; j<rooms.GetLength(1);j++)
	//			{
	//                if (rooms[i, j] != null)
	//                    print($"Room at [{i} , {j}]  exists ");
	//			}
	//		}
	//    }

	//    void Update()
	//    {

	//    }

	//     Vector2Int chooseNonOccupiedNeighbor(Vector2Int vec)
	//	{
	//        int[] fullI = { vec.x - 1, vec.x, vec.x + 1 };
	//		int[] neighboorI = { vec.x, vec.y };

	//		int[] fullJ = { vec.y - 1, vec.y, vec.y + 1 };
	//        int[] neighboorJ = { vec.y - 1, vec.y + 1 };

	//        int randI;
	//        int randJ;

	//        Vector2Int rand;
	//        do
	//        {
	//			//randI = -1;
	//			//randJ = -1;


	//			//         randI = UnityEngine.Random.Range(0, 3);

	//			//         if (randI==1)
	//			//{
	//			//             randJ = UnityEngine.Random.Range(0, 2);
	//			//             rand = new Vector2Int(iNeigh[randI], altJ[randJ]);
	//			//}

	//			//         else
	//			//{
	//			//             randJ = 1;
	//			//             rand = new Vector2Int(iNeigh[randI], jNeigh[randJ]);
	//			//}


	//			//randI = UnityEngine.Random.Range(0, 3);
	//			//if (iNeigh[randI] 
	//		}
	//        while (fullI[randI]>= 0 && fullI[randI] < 10 && fullJ[randJ] >= 0 && fullJ[randJ] < 10 && rooms[rand.x,rand.y] != null);

	//        return new Vector2Int(fullI[randI], fullJ[randJ]);
	//	}
}
