using UnityEngine;

public class Bridge : MonoBehaviour
{
	[SerializeField] public string direction;
	internal Vector3 positionTo;
	[SerializeField] internal Room roomTo;


	[SerializeField] bool isOpen = false;
	private void OnTriggerEnter(Collider other)
	{
		if(isOpen)
		if (other.gameObject.CompareTag("Player"))
		{
			other.GetComponent<Player>().movePlayerBetweenRooms(positionTo,roomTo);
		}
	}

	public void openBridge()
	{
		isOpen = true;
	}

}