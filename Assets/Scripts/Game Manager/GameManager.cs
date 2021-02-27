using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	GameManager manager;
	SceneLoader sceneLoader;
	[SerializeField] public State currentState;
	bool isChapiDead;

	// Start is called before the first frame update
	private void Awake()
	{
		initGameManagerSingelton();
		sceneLoader = GetComponent<SceneLoader>();
		GameManagerEvents.chapiDied.AddListener(chapiDiedCallback);
		chooseCurrentStateBasedOnScene();

	}

	private void OnLevelWasLoaded(int level)
	{
		chooseCurrentStateBasedOnScene();
	}

	void setCurrentState(State state)
	{
		currentState?.exitState();
		this.currentState = state;
		currentState?.enterState();
	}

	// Update is called once per frame
	void Update()
	{
		currentState?.tick();
		if (isChapiDead)
		{
			isChapiDead = false;
			currentState.exitState();
			moveToMainMenu();
		}
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
		sceneLoader.moveToNextLevel();
	}

	void chooseCurrentStateBasedOnScene()
	{

		//string[] sceneNames = sceneLoader.getSceneListInBuild();
		string scene = sceneLoader.getCurrentScene();
		switch (scene)
		{
			case "Guy StartMenu":
				{
					setCurrentState(new StartMenuState());
					break;
				}

			case "Guy's Stage1":
				{
					setCurrentState(new PlayGameState());
					break;
				}
		}
	}

	void chapiDiedCallback() => isChapiDead = true;
	public void moveToMainMenu()
	{
		sceneLoader.moveToMainMenu();
	}
}
