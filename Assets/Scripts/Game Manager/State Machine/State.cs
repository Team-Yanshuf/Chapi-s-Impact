
using UnityEngine;
[System.Serializable]
public abstract class State
{
    //Used so that each game state can communicate with the game manager.
    GameManager game;

    public State()
    {
        game = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //game.currentState.enterState();
    }
    public abstract void tick();

    public abstract void enterState();

    public abstract void exitState();
}
