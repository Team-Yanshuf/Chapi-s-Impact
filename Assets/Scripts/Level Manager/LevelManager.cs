using UnityEngine;


public class LevelManager : MonoBehaviour
{
    GameManager manager;
    LevelManager levelM;
    FogManager fogM;
    LevelSpawner spawner;
    NatureSpawner natureM;
    EnemyWaveManager waveM;
    Player player;

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
        waveM = GetComponent<EnemyWaveManager>();
        levelM = GetComponent<LevelManager>();
        natureM = GetComponent<NatureSpawner>();
        spawner = GetComponent<LevelSpawner>();
        fogM = GetComponent<FogManager>();


        updateCurrentEnemyCount();
        GameManagerEvents.enemyDefeated.AddListener(updateCurrentEnemyCount);
        GameManagerEvents.treePlanted.AddListener(updateTreesRequiered);


        //treesRequiredToBeat = 1;
    }

    private void Start()
    {
        fogM.initSelf();
        fogM.initFog();
        natureM.initSelf();
        waveM.initSelf();
        spawner.init();
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
        //print($"remaining waves: {waveM.getSpawnWaveManagerInfo().remainingNumberOfWaves} \t trees: {treesRequiredToBeat}");
        if (waveM.getSpawnWaveManagerInfo().remainingNumberOfWaves <= 0 && treesRequiredToBeat <= 0 && !beatenLevel)
        {
            beatenLevel = true;
            manager.beatLevel();
        }
    }

    public PollutionContainerInfo getPollutionInfo() => fogM.getPollutionInfo();

}
