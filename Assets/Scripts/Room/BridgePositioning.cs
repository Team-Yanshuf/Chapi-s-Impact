using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePositioning : MonoBehaviour
{
    Transform[] bridgePositions;
    bool[] adjecencyList;
    GameObject bridge;
	internal void init(bool[] adjecencyList)
	{
        bridgePositions = new Transform[4];
        foreach(Transform t in transform)
		{
            foreach(Transform m in t)
			{
                if (m.gameObject.name.Equals("Top"))
                    bridgePositions[0] = m;

                if (m.name.Equals("Left"))
                    bridgePositions[1] = m;

                if (m.name.Equals("Bottom"))
                    bridgePositions[2] = m;

                if (m.name.Equals("Right"))
                    bridgePositions[3] = m;
            }

        }
        //bridgePositions[0] = transform.Find("Top");
        //bridgePositions[1] = transform.Find("Left");
        //bridgePositions[2] = transform.Find("Bottom");
        //bridgePositions[3] = transform.Find("Right");
        this.adjecencyList = adjecencyList;
        bridge = Resources.Load<GameObject>("Rooms/Misc/Bridge");
        positionBridges();
	}

    void positionBridges()
	{
        for (int i=0; i<bridgePositions.Length; i++)
		{
            if (adjecencyList[i] && bridgePositions[i]!=null)
			{
                if (bridge!=null)
				{
                    GameObject obj = Instantiate<GameObject>(bridge, bridgePositions[i].position, Quaternion.identity);
                    obj.GetComponent<Bridge>().direction= bridgePositions[i].gameObject.name;
                }

			}
            else
			{
                //print("bridge position is null");
			}
		}
	}
}
