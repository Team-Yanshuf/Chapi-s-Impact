using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TrashcanEvents : MonoBehaviour
{
	public static UnityEvent jump = new UnityEvent();

	public static void onJump() => jump?.Invoke();
}
