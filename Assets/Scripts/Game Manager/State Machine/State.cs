
using UnityEngine;
public abstract class State
{
    //Used so that each game state can communicate with the game manager.
    GameManager game;

    public State()
    {
        game = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    public abstract void tick();

    public abstract void enterState();

    public abstract void exitState();

	public override string ToString()
	{
        return this.GetType().Name;
	}
}
