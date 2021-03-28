using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //KEEP TRACK OF HOW MANY TREES WERE PLANTED USING THE TREEPLANTED EVENT!!!
    [SerializeField] int initialFogCount;
    GameManager manager;
    LevelSpawner spawner;
    Player player;
    Vector3[] levelBoundries;
    int startingEnemyCount;
    int enemiesRequiredToPlant = 3;
   public  int enemiesRemainingToPlant = 3;
    int treesRequiredToBeat;
    int currentEnemyCount;
    int treesPlanted;

    bool beatenLevel = false;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        levelBoundries = new Vector3[8];
        initLevelBoundries();
        updateCurrentEnemyCount();
        GameManagerEvents.enemyDefeated.AddListener(updateCurrentEnemyCount);
        GameManagerEvents.treePlanted.AddListener(updateTreesRequiered);
        treesRequiredToBeat = 1;
    }

	private void Update()
	{
        //displayHP();
        checkForLevelBeaten();
        updateEnemyCount();
	}

	public int getInitialFogCount() => initialFogCount;

 
    private void updateCurrentEnemyCount()
	{
        checkAndApprovePlanting();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        startingEnemyCount = enemies.Length;
        currentEnemyCount = enemies.Length;
	}

    void updateEnemyCount()
	{
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        currentEnemyCount = enemies.Length;
    }

    public int getCurrentEnemyCount()
	{
        return startingEnemyCount;
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
		{   trans2[i] = trans[i+1];	}

        for(int i=0; i<trans2.Length; i++)
		{   levelBoundries[i] = trans2[i].position;	}
	}

	internal void requestMoveToMainMenu()
	{
        manager.moveToMainMenu();
	}
    
    void checkAndApprovePlanting()
	{
        enemiesRemainingToPlant--;
        currentEnemyCount--;
        if (enemiesRemainingToPlant==0)
		{
            player.grantPlantPremission();
            enemiesRemainingToPlant = enemiesRequiredToPlant;
		}
 
    }

    void displayHP() => print(player.getHP());

    void updateTreesRequiered()
	{
        treesRequiredToBeat--;
	}

    void checkForLevelBeaten()
	{

        //print("Trees: " + treesRequiredToBeat + "\tEnemies: " + currentEnemyCount);
        if (currentEnemyCount<=0 && treesRequiredToBeat<=0 && !beatenLevel)
		{
            beatenLevel = true;
           // print("Beaten!");
            manager.beatLevel();
		}
	}
}
