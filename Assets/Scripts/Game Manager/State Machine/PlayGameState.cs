using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

public class PlayGameState : State
{ 
	override public void tick()
	{
		//Enable gameplay.
	}

	override public void enterState()
	{ 

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
}
