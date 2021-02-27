using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class implementing an abstract level state.
public abstract class LevelState : State
{
    int initialFogCount; 
    FogParticle fogPrefab;
    bool chapiDied = false;

    protected LevelManager levelM;
    int currentFogCount;

   protected List<FogParticle> fogs;
   Vector3[] levelBoundries;

   protected Player player;

    protected int numberOfEnemies;
    int fogDeclineRate;
    
    public LevelState()
    { 
        GameManagerEvents.enemyDefeated.AddListener(clearFog);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        levelM = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        levelM = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        fogPrefab = Resources.Load<FogParticle>("FogParticle/FogParticle");
     
        initialFogCount = levelM.getInitialFogCount();
        Debug.Log(initialFogCount);
	}

    public override void enterState()
	{
        levelBoundries = levelM.getLevelBoundries();
        initFog();

    }

	public override void exitState()
	{
        Debug.Log("exit called");
        GameManagerEvents.enemyDefeated.RemoveAllListeners();
        foreach (FogParticle fog in fogs)
        {
            Object.Destroy(fog.gameObject);
        }
        fogs.RemoveRange(0, fogs.Count);

    }

	void initFog()
	{
        fogs = new List<FogParticle>();
        GameObject fogContainer = new GameObject();
        fogContainer.gameObject.name = "Fog Container";
        for (int i=0; i<initialFogCount; i++)
		{      
            float x = Random.Range(levelBoundries[0].x, levelBoundries[1].x);
            float y = Random.Range(levelBoundries[2].y, levelBoundries[0].y);
            float z = Random.Range(levelBoundries[0].z, levelBoundries[2].z);

            Vector3 position = new Vector3(x, y, z);
            FogParticle particle = GameObject.Instantiate(fogPrefab, position, Quaternion.identity);
            fogs.Add(particle);
            particle.transform.parent = fogContainer.transform;
		}
	}

	void clearFog()
	{
        for (int i=0; i<fogs.Count; i++)
		{
            int indexToRemove = Random.Range(0, currentFogCount);
            Object.Destroy(fogs[i].gameObject);
            fogs.RemoveAt(i);
		}

	}

}
