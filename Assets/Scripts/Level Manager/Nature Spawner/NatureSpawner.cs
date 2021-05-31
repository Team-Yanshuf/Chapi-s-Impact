using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureSpawner : MonoBehaviour
{
    //LevelManager levelM;
    List<GameObject> spawnPoints;
    Room room;
    RoomInfo roomInfo;

    bool ready=false;

    public void initSelf()
	{
        //levelM = GetComponent<LevelManager>();
        room = GetComponent<Room>();
        spawnPoints = getSpawnPointList();
        StartCoroutine(setPollutionInfoCoroutine());


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
        }
    }

	private void LateUpdate()
	{
        if(ready)
        setPollutionInfo();
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
