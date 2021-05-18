using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] public string direction;
	internal Vector3 positionTo;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.GetComponent<Player>().movePlayerBetweenRooms(positionTo);
		}
	}

}


