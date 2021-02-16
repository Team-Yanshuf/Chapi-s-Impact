using UnityEngine;

public class GameManager : MonoBehaviour
{
	GameManager manager;
	public State currentState;

	void setCurrentState(State state)
	{
		currentState.exitState();
		this.currentState = state;
		currentState.enterState();
	}
	
	// Start is called before the first frame update
	private void Awake()=>initGameManagerSingelton();
	

	// Update is called once per frame
	void Update()
	{
		checkForPause();
		currentState?.tick();
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
}
