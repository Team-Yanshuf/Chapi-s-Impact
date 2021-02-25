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
        initLevelBoundries();
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
        Transform[] trans2 = new Transform[trans.Length - 1];
        for (int i=0; i<trans2.Length;i++)
		{
            trans2[i] = trans[i+1];
		}
        for(int i=0; i<trans2.Length; i++)
		{
            Debug.Log(trans2[i].gameObject.name);
            levelBoundries[i] = trans2[i].position;
		}
        
	}









}
