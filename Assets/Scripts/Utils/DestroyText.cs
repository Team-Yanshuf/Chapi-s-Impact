using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText : MonoBehaviour
{
	Timer timer;

	private void Start()
	{
		timer = GetComponent<Timer>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			timer.setParameters(5, destroy);
			timer.fire();
		}
	}

	void destroy()
	{
		Destroy(this.gameObject);
	}
}
