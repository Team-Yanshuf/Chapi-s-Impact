using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralUtils
{
     public static float getRandomValueInRange(float a, float b)
	{
		float min = a > b ? b : a;
		float max = a > b ? a : b;
		System.Random rand = new System.Random();
		float randomValue = ((float)(rand.NextDouble()) *(Mathf.Abs(max-min))) + min;
		Debug.Log("Random Value: " + randomValue);
		return randomValue;
	}
}
