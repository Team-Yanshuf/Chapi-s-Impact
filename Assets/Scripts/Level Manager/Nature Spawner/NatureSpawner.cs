using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureSpawner : MonoBehaviour
{
    LevelManager levelM;
    List<GameObject> spawnPoints;

    PollutionContainerInfo pollutionInfo;
    void Start()
    {

    }

    public void initSelf()
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
    }

	private void LateUpdate()
	{
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
