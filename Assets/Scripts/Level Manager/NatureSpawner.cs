using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureSpawner : MonoBehaviour
{
    LevelManager levelM;

    PollutionContainerInfo pollutionInfo;
    // Start is called before the first frame update
    void Start()
    {
        levelM = GetComponent<LevelManager>();
        StartCoroutine(setPollutionInfo());
    }


    IEnumerator setPollutionInfo()
	{
       yield return new WaitForSeconds(2);
        pollutionInfo = levelM.getPollutionInfo();

        while(true)
		{
            print(levelM.getPollutionInfo());
            yield return null;
        }

        //yield break;

    }        

    // Update is called once per frame
    void Update()
    {
       // if (pollutionInfo!=null)

    }
}
