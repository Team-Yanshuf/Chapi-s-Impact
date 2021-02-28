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
        GameManagerEvents.enemyDefeated.AddListener(clearFogBy20Precent);
        GameManagerEvents.treePlanted.AddListener(clear200FogParticles);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        levelM = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        levelM = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        fogPrefab = Resources.Load<FogParticle>("FogParticle/FogParticle");
     
        initialFogCount = levelM.getInitialFogCount();
	}

    public override void enterState()
	{
        levelBoundries = levelM.getLevelBoundries();
        initFog();

    }

	public override void exitState()
	{
        GameManagerEvents.enemyDefeated.RemoveAllListeners();
        foreach (FogParticle fog in fogs)
        {
            Object.Destroy(fog.gameObject);
        }
        fogs.Clear();

    }

	void initFog()
	{
        fogs = new List<FogParticle>();
        GameObject fogContainer = new GameObject();
        fogContainer.tag = "FogContainer";
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

	void clearFogBy20Precent()
	{
        int amount = (int) (fogs.Count * 0.2);
        for (int i = 0; i < amount ; i++)
        {
            int indexToRemove = Random.Range(0, currentFogCount);
            Object.Destroy(fogs[indexToRemove].gameObject);
            fogs.RemoveAt(indexToRemove);
        }

    }

    void clear200FogParticles()
	{
       for (int i=0; i<fogs.Count && i<200;i++)
		{
            int indexToRemove = Random.Range(0, currentFogCount);
            Object.Destroy(fogs[indexToRemove].gameObject);
            fogs.RemoveAt(indexToRemove);
        }

    }


}
