using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class implementing an abstract level state;
public abstract class LevelState : State
{
    //CANT SERIALIZE A NON MONOBEHAVIOUR CLASS!!!
    int startingFogCount; 
    FogParticle fogPrefab;

    //TODO: FIND A WAY TO CATCH A REFERENCE TO THE FOG PREFAB!!!

    LevelManager levelM;
    int currentFogCount;

    List<FogParticle> fogs;
    Vector3[] levelBoundries;
    
    
    public LevelState()
	{
        startingFogCount = 100;
       // enterState();
	}

    public override void enterState()
	{
        levelM = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        levelBoundries = levelM.getLevelBoundries();
        fogPrefab = Resources.Load<FogParticle>("FogParticle/FogParticle");
		StartCoroutine(initFog());
    }
    
    IEnumerator initFog()
	{
        fogs = new List<FogParticle>();

        for (int i=0; i<startingFogCount; i++)
		{
            float x = Random.Range(levelBoundries[0].x, levelBoundries[1].x);
            float y = Random.Range(levelBoundries[2].y, levelBoundries[3].y);
            float z = levelBoundries[0].z;

            Vector3 position = new Vector3(x, y, z);
            FogParticle particle = GameObject.Instantiate(fogPrefab,position,Quaternion.identity);
            fogs.Add(particle);
            yield return null;
		}
	}
    IEnumerator clearFog()
	{
        for (int i=0; i<currentFogCount/10; i++)
		{
            int indexToRemove = Random.Range(0, currentFogCount);
            GameObject.Destroy(fogs[indexToRemove]);
            fogs.RemoveAt(indexToRemove);
            yield return null;
		}

	}





}
