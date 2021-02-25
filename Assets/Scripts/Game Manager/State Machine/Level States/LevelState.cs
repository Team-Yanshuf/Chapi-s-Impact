using System.Threading;
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
        startingFogCount = 400;

	}

    public override void enterState()
	{
        Debug.Log("Entered State on LevelState");
        levelM = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        levelBoundries = levelM.getLevelBoundries();
        fogPrefab = Resources.Load<FogParticle>("FogParticle/FogParticle");
        //new Thread(new ThreadStart(initFog)).Start();
        initFog();
    }
    
    void initFog()
	{
        fogs = new List<FogParticle>();

        for (int i=0; i<startingFogCount; i++)
		{
            
            float x = Random.Range(levelBoundries[0].x, levelBoundries[1].x);
            float y = Random.Range(levelBoundries[2].y, levelBoundries[0].y);
            if (i%10==0)
			{
                Debug.Log("X: " + x + "\tY:" + y);
			}
            float z = levelBoundries[0].z;

            Vector3 position = new Vector3(x, y, z);
            instantiateParticle(position, Quaternion.identity);


            
		}
	}

	private void instantiateParticle(Vector3 position, Quaternion rotation)
	{
        FogParticle particle = GameObject.Instantiate(fogPrefab, position, rotation);
        fogs.Add(particle);
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
