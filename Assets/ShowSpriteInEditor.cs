using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSpriteInEditor : MonoBehaviour
{
	NatureType type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void makeSpriteAppearInEditor()
	{
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		switch (type)
		{
			case NatureType.ROCK1:
				{
					renderer.sprite = Resources.Load<GameObject>("Nature/Rock1").GetComponent<SpriteRenderer>().sprite; ;

					break;
				}

			case NatureType.ROCK2:
				{
					renderer.sprite = Resources.Load<GameObject>("Nature/Rock2").GetComponent<SpriteRenderer>().sprite; ;
					break;
				}

			case NatureType.ROCK3:
				{
					renderer.sprite = Resources.Load<GameObject>("Nature/Rock3").GetComponent<SpriteRenderer>().sprite; ;
					break;
				}
			case NatureType.TREE1:
				{
					renderer.sprite = Resources.Load<GameObject>("Nature/Tree1").GetComponent<SpriteRenderer>().sprite; ;
					break;
				}
		}
	}
}
