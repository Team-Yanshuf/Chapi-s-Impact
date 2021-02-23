using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    LevelSpawner spawner;
    Vector3[] levelBoundries;
    // Start is called before the first frame update
    void Awake()
    {
        levelBoundries = new Vector3[4];
    }



    int getCurrentEnemyCount()
	{
        return 0;
	}

    int getInitialEnemyCount()
	{
        return 0;
	}

    public Vector3[] getLevelBoundries()
	{
        return levelBoundries;
	}

    private void initLevelBoundries()
	{
       Transform[] trans= transform.Find("LevelBoundries").GetComponentsInChildren<Transform>();
        for(int i=0; i<trans.Length; i++)
		{
            levelBoundries[i] = trans[i].position;
		}
        
	}









}
