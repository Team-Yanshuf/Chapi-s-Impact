using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class implementing an abstract level state.
public abstract class LevelState : State
{
    int startingFogCount; 
    FogParticle fogPrefab;

    LevelManager levelM;
    int currentFogCount;

    List<FogParticle> fogs;
    Vector3[] levelBoundries;

    int numberOfEnemies;
    int fogDeclineRate;
    
    public LevelState()
	{
        startingFogCount = 400;
        GameManagerEvents.enemyDefeated.AddListener(clearFog);

	}

    public override void enterState()
	{
        levelM = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        levelBoundries = levelM.getLevelBoundries();
        fogPrefab = Resources.Load<FogParticle>("FogParticle/FogParticle");

        initFog();
    }

	public override void exitState()
	{
        GameManagerEvents.enemyDefeated.RemoveAllListeners();
	}

	void initFog()
	{
        fogs = new List<FogParticle>();
        GameObject fogContainer = new GameObject();
        fogContainer.gameObject.name = "Fog Container";
        for (int i=0; i<startingFogCount; i++)
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
