using UnityEngine;

public class GameManager : MonoBehaviour
{
	static GameManager manager;
	SceneLoader sceneLoader;
	bool isChapiDead;
	Timer timer;

	private void Awake()
	{
		sceneLoader = GetComponent<SceneLoader>();
		GameManagerEvents.chapiDied.AddListener(chapiDiedCallback);
		timer = GetComponent<Timer>();
	}

	private void Start()
	{
		initGameManagerSingelton();
		//******************Set target frame rate to 60*******************//
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 100;
		//******************Set target frame rate to 60*******************//
	}

	private void OnLevelWasLoaded(int level)
	{
		isChapiDead = false;
	}


	void Update()
	{
		if (isChapiDead)
		{
			isChapiDead = false;
			moveToMainMenu();
		}


		//EXIT GAME
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}


	void initGameManagerSingelton()
	{
		if (!manager)
		{
			manager = this;
			DontDestroyOnLoad(this.gameObject);
		}

		else
		{
			Destroy(this.gameObject);
		}
	}



	public void moveToFirstLevel()
	{
		sceneLoader.moveToFirstLevel();
	}

	void moveToNextLevel()
	{
		sceneLoader.moveToNextLevel();
	}
	void chapiDiedCallback() => isChapiDead = true;
	public void moveToMainMenu()
	{
		sceneLoader.moveToMainMenu();
	}

	internal void BeatLevel()
	{
		if (!timer.isRunning())
		{
			timer.setParameters(1, sceneLoader.moveToWinScene);
			timer.fire();
		}

	}

	void moveWin()
	{
		sceneLoader.moveToWinScene();
	}

	public void quit()
	{
		Application.Quit();
	}

}
