using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
	[SerializeField] FMODUnity.StudioEventEmitter over;
	[SerializeField] FMODUnity.StudioEventEmitter click;
	
	bool isOver = false;


	public void onOver()
	{
		//if (!isOver)
		{
			print("PlayOnOver");
			isOver = true;
			over.Play();
		}
	}

	private void OnMouseExit()
	{
		isOver = false;
	}

	public  void onClick()
	{
		print("Play On CLick");
		click.Play();
	}

}
