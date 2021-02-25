using UnityEngine;

public class GameManager : MonoBehaviour
{
	GameManager manager;
	SceneLoader sceneLoader;
	[SerializeField] public State currentState;



	// Start is called before the first frame update
	private void Awake()
	{
		initGameManagerSingelton();
		sceneLoader = GetComponent<SceneLoader>();
		chooseCurrentStateBasedOnScene();

	}

	private void OnLevelWasLoaded(int level)
	{
		chooseCurrentStateBasedOnScene();
	}

	void setCurrentState(State state)
	{
		currentState.exitState();
		this.currentState = state;
		currentState.enterState();
	}

	// Update is called once per frame
	void Update()
	{
		checkForPause();
		currentState?.tick();
	}


	void checkLevelLoader()
	{
		sceneLoader.moveToFirstLevel();
		Debug.Log(sceneLoader.getCurrentScene());
		
	}

	void checkForPause()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			currentState?.exitState();
			setCurrentState(new GamePauseState());
		}
	}

	void initGameManagerSingelton()
	{
		if (!manager)
		{
			manager = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}


	void moveToGameplay()
	{
		setCurrentState(new PlayGameState());
	}

	public void moveToFirstLevel()
	{
		sceneLoader.moveToFirstLevel();
	}

	void moveToNextLevel()
	{
		//sceneLoader.moveToNextLevel();z
	}

	void chooseCurrentStateBasedOnScene()
	{

		string[] sceneNames = sceneLoader.getSceneListInBuild();
		string scene = sceneLoader.getCurrentScene();
		switch (scene)
		{
			case "Guy StartMenu":
				{
					currentState=new StartMenuState();
					break;
				}

			case "Guy's Stage1":
				{

					setCurrentState(new PlayGameState());
					break;
				}
		}
	}
}
