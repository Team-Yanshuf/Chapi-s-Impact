using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomEvents : MonoBehaviour
{
	bool ready = false;
	public UnityEvent dwindleLocalFog;
	public UnityEvent treePlanted;

	public void initEvents()
	{
		dwindleLocalFog = new UnityEvent();
		dwindleLocalFog = new UnityEvent();
		ready = true;
	}


}
