using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlanting : MonoBehaviour
{
    bool planting = false;
    Tree tree;
    Player playerM;
    bool plantLocked = false;
    float direction;
    int treesToPlant = 0;
    int frameCount;
    bool activateFrameCount;

    [Header("Timing of planting events in frames")]
    [SerializeField] int framesUntilPlanting;
    [SerializeField] int framesUntilEnding;
    [SerializeField] float zOffset;



    // Start is called before the first frame update
    void Start()
    {
        playerM = GetComponent<Player>();
        tree = Resources.Load<Tree>("TreeOfLife");
        frameCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerM.plantingPressed() && !plantLocked && playerM.getHowManyTreesCanPlant()>0)
		{
            plantLocked = true;
            playerM.setPlanting(true);
            //Get a consistent amount of real time regardless of frameRate;
            //CHANGE TO NOT HARDCODED VALUES!!!
            //Invoke("plant",0.4f);
            //Invoke("endPlanting", 1.33f);
            activateFrameCount = true;
        }
        direction = playerM.getChapiDirection();
        //adjustDirectionToFitTreePivot();
        if (activateFrameCount)
		{
            frameCount++;
            if (frameCount == framesUntilPlanting)
                plant();

            else if (frameCount == framesUntilEnding)
			{
                endPlanting();
                activateFrameCount = false;
                frameCount = 0;
            }

		}
    }

    void adjustDirectionToFitTreePivot()
	{
        if (direction < 0)
            direction *= 4;
	}

    public bool isPlanting()
    {
        return planting;
    }

    void plant()
	{
        Vector3 offset = new Vector3(direction, 0, zOffset) ;
        Instantiate(tree, transform.position + offset , Quaternion.identity);
	}

    void endPlanting()
	{
        playerM.setPlanting(false);
        GameManagerEvents.treePlanted.Invoke();
        plantLocked = false;
	}


}
