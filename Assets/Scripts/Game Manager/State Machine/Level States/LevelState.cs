using UnityEngine;

//Class implementing an abstract level state.
public abstract class LevelState : State
{
    bool chapiDied = false;
    protected LevelManager levelM;
    protected Player player;
    protected int numberOfEnemies;
    
    public LevelState()
    { 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        levelM = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
	}

    public override void enterState()
	{
    }

    
	public override void exitState()
	{
    }

}
