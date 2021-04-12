using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureSpawner : MonoBehaviour
{
    LevelManager levelM;
    List<GameObject> spawnPoints;

    PollutionContainerInfo pollutionInfo;
    // Start is called before the first frame update
    void Start()
    {
        levelM = GetComponent<LevelManager>();
        spawnPoints = getSpawnPointList();
        StartCoroutine(setPollutionInfoCoroutine());
    }

    void Update()
    {
        foreach (GameObject obj in spawnPoints)
           {
                NatureSpawnPoint point = obj.GetComponent<NatureSpawnPoint>();
                if (point.isActive())
                {
                    point.setFogDone(pollutionInfo.finishedLoading);
                    point.setFogState(pollutionInfo.remainingFogPrecentage);
                }

            }
        setPollutionInfo();
    }


    void setPollutionInfo()
	{
        pollutionInfo=levelM.getPollutionInfo();
	}
    IEnumerator setPollutionInfoCoroutine()
	{
       yield return new WaitForSeconds(2);
        pollutionInfo = levelM.getPollutionInfo();
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
