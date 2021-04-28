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

    [SerializeField] float zOffset;



    // Start is called before the first frame update
    void Start()
    {
        playerM = GetComponent<Player>();
        tree = Resources.Load<Tree>("TreeOfLife");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerM.plantingPressed() && !plantLocked && playerM.getHowManyTreesCanPlant()>0)
		{
            plantLocked = true;
            playerM.setPlanting(true);

            //CHANGE TO NOT HARDCODED VALUES!!!
            Invoke("plant",0.4f);
            Invoke("endPlanting", 1.33f);
    
        }
        direction = playerM.getChapiDirection();
        //adjustDirectionToFitTreePivot();

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
