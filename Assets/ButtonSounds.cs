using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
	[SerializeField] FMODUnity.StudioEventEmitter onOver;
	[SerializeField] FMODUnity.StudioEventEmitter onClick;
	
	bool isOver = false;


	private void OnMouseOver()
	{
		if (!isOver)
		{
			isOver = true;
			onOver.Play();
		}
	}

	private void OnMouseExit()
	{
		isOver = false;
	}

	private void OnMouseDown()
	{
		onClick.Play();
	}

}
