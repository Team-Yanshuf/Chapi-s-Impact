using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class implementing an abstract level state.
public abstract class LevelState : State
{
    int initialFogCount; 
    FogContainer pollution;
    bool chapiDied = false;

    BoxCollider fogBoundries;
    protected LevelManager levelM;

   protected List<FogParticle> fogs;

   protected Player player;

    protected int numberOfEnemies;
    
    public LevelState()
    { 
        GameManagerEvents.enemyDefeated.AddListener(clearFogBy20Precent);
        GameManagerEvents.treePlanted.AddListener(clear200FogParticles);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        levelM = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        fogBoundries = levelM.GetComponentInChildren<BoxCollider>();
     
        initialFogCount = levelM.getInitialFogCount();
	}

    public override void enterState()
	{
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
        pollution = GameObject.Instantiate(Resources.Load<FogContainer>("FogContainer/FogContainer"));
        pollution.setBounds(fogBoundries);
        pollution.setFogCount(initialFogCount);
        pollution.setFogTransform(levelM.transform.Find("LevelBoundries").transform);
        pollution.initFog();
	}

	void clearFogBy20Precent()
	{
        pollution.dwindleByPrecentage(20);
    }

    void clear200FogParticles()
	{
        pollution.dwindleByAmout(200);
    }






}
