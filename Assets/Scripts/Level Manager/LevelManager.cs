using UnityEngine;


public class LevelManager : MonoBehaviour
{
    GameManager manager;
    LevelManager levelM;
    RoomsManager roomM;
    public static Player player;

    int startingEnemyCount;
    int enemiesRequiredToPlant = 3;
    public int enemiesRemainingToPlant = 3;
    [SerializeField] int treesRequiredToBeat;
    int currentEnemyCount;
    int treesPlanted;


    


    bool beatenLevel = false;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        levelM = GetComponent<LevelManager>();
        roomM = GetComponent<RoomsManager>();

        updateCurrentEnemyCount();
        GameManagerEvents.enemyDefeated.AddListener(updateCurrentEnemyCount);
        GameManagerEvents.treePlanted.AddListener(updateTreesRequiered);


        //treesRequiredToBeat = 1;
    }

    private void Start()
    {
        //fogM.initSelf();
        //fogM.initFog();
        //natureM.initSelf();
        //waveM.initSelf();
        roomM.InitSelf();
    }

    private void Update()
    {
		checkForLevelBeaten();
		updateEnemyCount();
    }


    //Used to check if chapi can plant or not.
    //Consider: Moving Planting logic into j
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
    //internal void requestMoveToMainMenu()
    //{
    //    manager.moveToMainMenu();
    //}
    void checkAndApprovePlanting()
    {
        enemiesRemainingToPlant--;
        currentEnemyCount--;
        if (enemiesRemainingToPlant == 0)
        {
            player.grantPlantPremission();
            enemiesRemainingToPlant = enemiesRequiredToPlant;
        }

    }
    void updateTreesRequiered()
    {
        treesRequiredToBeat--;
    }
	void checkForLevelBeaten()
	{
        RoomInfo[] rooms = levelM.getRoomManagerInfo().rooms;
        foreach(RoomInfo info in rooms)
		{
            if (!info.wavesInfo.AreAllWavesDefeatedInRoom)
                return;
		}

        manager.BeatLevel();
	}

	//public PollutionContainerInfo getPollutionInfo() => fogM.getPollutionInfo();
	public RoomManagerInfo getRoomManagerInfo() => roomM.getRoomManagerInfo();
}
