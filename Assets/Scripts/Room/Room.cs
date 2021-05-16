using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    BridgePositioning bridgeM;
    bool[] adjecencyList;
    // Start is called before the first frame update

    public void init(bool[] adjecencyList)
	{
        bridgeM = GetComponent<BridgePositioning>();
        this.adjecencyList = adjecencyList;
        bridgeM.init(adjecencyList);
    }

	internal void setAdjecencyList(bool[] list)
	{
        this.adjecencyList = list;
	}
}
