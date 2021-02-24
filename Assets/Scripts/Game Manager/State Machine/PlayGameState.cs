using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

public class PlayGameState : State
{

	//PlayGameState is its own state machine.
	//it moves between levels, keeping information about:
	//the player, current enemies, game status and more.
	State currentState;
	GameManager manager;

	public PlayGameState()
	{
		manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}

	override public void tick()
	{
		//Enable gameplay.
	}

	override public void enterState()
	{
		setCurrentstate(new Level1State());
		//Invoke UnityEvent for starting the game:
		//Listeners of this event will:
		//1.Switch to first game scene
		//2.Turn of all menu scenes
		//3.Probably some other stuff.
	}

	override public void exitState()
	{
		//Invoke UnityEvent for ending the game:
		//Listeners of this event will:
		//1.Switch to menu scene?
	}

	public void setCurrentstate(State nextState)
	{
		currentState.exitState();
		currentState = nextState;
		currentState.enterState();
	}
}
