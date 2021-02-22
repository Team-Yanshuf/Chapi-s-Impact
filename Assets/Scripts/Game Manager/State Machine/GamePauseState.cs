using UnityEngine;
using UnityEngine.Events;
public class GamePauseState : State
{
    GameManager manager;
    public override void enterState()
    {
        GameManagerEvents.onPause();
        loadMenu();
    }
    public override void exitState()
    {
        GameManagerEvents.onResume();
    }

    public override void tick()
    {
        //Load and maintain pause menu

        //check for resume
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitState();
        }
    }

    private void loadMenu()
    {

    }
}
