using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NatureSpawner : MonoBehaviour
{
    //LevelManager levelM;
    List<GameObject> spawnPoints;
    Room room;
    RoomInfo roomInfo;
    GameObject[] floors;
    bool ready=false;

    public void initSelf()
	{
        floors = new GameObject[4];
        room = GetComponent<Room>();
        spawnPoints = getSpawnPointList();
        StartCoroutine(setPollutionInfoCoroutine());

            foreach (Transform t in transform)
            {
                if (t.gameObject.name.Equals("Stage4"))
                {
                    floors[0] = t.gameObject;
                    break;
                }

            }

        ready = true;
    }

    void Update()
    {
        if (ready)// && room.getRoomInfo().isActive)
		{
            foreach (GameObject obj in spawnPoints)
            {
                NatureSpawnPoint point = obj.GetComponent<NatureSpawnPoint>();
                if (point.isActive())
                {
                    point.setFogDone(roomInfo.finishedLoading);
                    point.setFogState(roomInfo.containerInfo.remainingFogPrecentage);
                }
            }

            //int current = (int) (4- Mathf.Ceil((room.getRoomInfo().containerInfo.remainingFogPrecentage/100f) * 4));
            //float opacity = (float)(room.getRoomInfo().containerInfo.remainingFogPrecentage);
          //  print(room.getRoomInfo().containerInfo.remainingFogPrecentage) ;
            //floors[0].GetComponent<Tilemap>().color= new Color(1,1,1,opacity);
   //         for(int i=0; i<floors.Length; i++)
			//{
   //             print(current);
   //             if (i == current)
   //             {
   //                 floors[i].SetActive(true);
   //             }
   //             else
   //                 floors[i].SetActive(false);
			//}


        }
    }

	private void LateUpdate()
	{
        if(ready)
        setPollutionInfo();
	}

    void handleFloorSwap()
	{

	}

	void setPollutionInfo()
	{
        roomInfo=room.getRoomInfo();
	}
    IEnumerator setPollutionInfoCoroutine()
	{
       yield return new WaitForSeconds(2);
        roomInfo = room.getRoomInfo();
    }
    List<GameObject> getSpawnPointList()
	{
        List<GameObject> list = new List<GameObject>();
        Transform trans= transform.Find("NatureSpawnPoints");

        foreach (Transform t in trans)
		{
            list.Add(t.gameObject);
		}

        return list;

	}





}
