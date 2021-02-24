using UnityEngine;

public class GameManager : MonoBehaviour
{
	GameManager manager;
	SceneLoader sceneLoader;
	public State currentState;

	void setCurrentState(State state)
	{
		currentState.exitState();
		this.currentState = state;
		currentState.enterState();
	}

	// Start is called before the first frame update
	private void Awake()
	{
		initGameManagerSingelton();
		sceneLoader = GetComponent<SceneLoader>();

		//*******TEMP- REMOVE THiS************//
		//if (sceneLoader.getCurrentScene().Equals("Guy's Stage1"))
		{
			moveToGameplay();
		}
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

}
