using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level1State : LevelState
{
    // Start is called before the first frame update

	public Level1State()
	{
		//enterState is called because Level1State is the
		//first state to occupy GameplayState.currentState,
		//so setCurrentState can't be called because there was no
		//previous state.
		//enterState();
	}
	public override void exitState()
	{

	}

	public override void enterState()
	{
		base.enterState();

	}
	public override void tick()
	{

	}
}
