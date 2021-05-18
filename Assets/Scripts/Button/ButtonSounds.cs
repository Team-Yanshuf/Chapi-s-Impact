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
		click.Play();
	}

}
