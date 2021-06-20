﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
	static GameManager manager;
	SceneLoader sceneLoader;
	//[SerializeField] public State currentState;
	bool isChapiDead;

	Timer timer;

	// Start is called before the first frame update
	private void Awake()
	{
		//initGameManagerSingelton();
		sceneLoader = GetComponent<SceneLoader>();
		GameManagerEvents.chapiDied.AddListener(chapiDiedCallback);
		//chooseCurrentStateBasedOnScene();
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
		//	initGameManagerSingelton();
		//schooseCurrentStateBasedOnScene();
	}

	//void setCurrentState(State state)
	//{
	//	currentState?.exitState();
	//	this.currentState = state;
	//	currentState?.enterState();
	//}

	void Update()
	{
		//currentState?.tick();
		if (isChapiDead)
		{
			isChapiDead = false;
			//currentState?.exitState();
			moveToMainMenu();
		}


		//EXIT GAME
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();

		//if (Input.GetKeyDown(KeyCode.S))
		//{
		//	print(currentState);
		//}
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


	//void moveToGameplay()
	//{
	//	setCurrentState(new PlayGameState());
	//}

	public void moveToFirstLevel()
	{
		sceneLoader.moveToFirstLevel();
	}

	void moveToNextLevel()
	{
		sceneLoader.moveToNextLevel();
	}

	//void chooseCurrentStateBasedOnScene()
	//{

	//	//string[] sceneNames = sceneLoader.getSceneListInBuild();
	//	string scene = sceneLoader.getCurrentScene();
	//	switch (scene)
	//	{
	//		case "Guy StartMenu":
	//			{
	//				setCurrentState(new StartMenuState());
	//				break;
	//			}

	//		case "Yinon'sStage001":
	//			{
	//				setCurrentState(new PlayGameState());
	//				break;
	//			}

	//		case "Guy's Stage1":
	//			{
	//				setCurrentState(new PlayGameState());
	//				break;
	//			}

	//		case "FullGameLoop":
	//			{
	//				setCurrentState(new PlayGameState());
	//				break;
	//			}

	//		//case "Guy's Stage1":
	//		//	{
	//		//		setCurrentState(new PlayGameState());
	//		//		break;
	//		//	}
	//	}
	//}

	void chapiDiedCallback() => isChapiDead = true;
	public void moveToMainMenu()
	{
		sceneLoader.moveToMainMenu();
	}

	internal void beatLevel()
	{
		timer.setParameters(1, sceneLoader.moveToWinScene);
		timer.fire();
	}

	void moveWin()
	{
		sceneLoader.moveToWinScene();
	}

}
