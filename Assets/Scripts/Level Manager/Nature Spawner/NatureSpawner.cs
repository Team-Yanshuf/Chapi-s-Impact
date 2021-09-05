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
        floors = new GameObject[2];
        room = GetComponent<Room>();
        spawnPoints = getSpawnPointList();
        StartCoroutine(setPollutionInfoCoroutine());

            foreach (Transform t in transform)
            {
            if (t.gameObject.name.Equals("Stage1"))
            {
                floors[0] = t.gameObject;
            }

            else if (t.gameObject.name.Equals("Stage4"))
            {
                floors[1] = t.gameObject;
            }

            else if (floors[0] && floors[1])
                break;

            }

            foreach(GameObject point in spawnPoints)
		    {
                point.GetComponent<NatureSpawnPoint>().initSelf(room.getRoomInfo());
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
                    point.setRoomState(room.getRoomInfo());
  
                }
            }
            float fogPrecent = (room.getRoomInfo().containerInfo.RemainingFogPrecentage);
            floors[0].GetComponent<Tilemap>().color= new Color(1,1,1, fogPrecent);
            floors[1].GetComponent<Tilemap>().color = new Color(1, 1, 1, 1f- fogPrecent);

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
