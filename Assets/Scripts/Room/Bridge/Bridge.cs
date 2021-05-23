using UnityEngine;

public class Bridge : MonoBehaviour
{
	[SerializeField] public string direction;
	internal Vector3 positionTo;
	[SerializeField] internal Room roomTo;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.GetComponent<Player>().movePlayerBetweenRooms(positionTo,roomTo);
		}
	}

}


