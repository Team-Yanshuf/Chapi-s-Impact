using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightingManager : MonoBehaviour
{

    // Range 0.1 to 0.8
    [SerializeField] Light2D light;
    [SerializeField] float min;
    [SerializeField] float max;

    Room roomM;

    float currentIntensity;
    public void initSelf(Light2D source)
    {
        light = source;
        light.intensity = 0.1f;
        roomM = GetComponent<Room>();
        min = 0.1f;
        max = 0.8f;
    }

	internal void adaptLightingToEnemyDeath()
	{
            setCurrentIntensity();
            light.intensity = currentIntensity;

			////StartCoroutine(co());

			//IEnumerator co()
			//{
			//	for (int i = 0; i < 100; i++)
			//	{
			//		light.intensity += 0.01f;
			//		yield return null;
			//	}
			//}

	}

    internal void adaptLightingToTreePlanted()
	{
        adaptLightingToEnemyDeath();
	}

    float normalizeValueInRange(float val)
	{
        float newV = (val - min) / (max - min);
        return newV;
	}

    void setCurrentIntensity()
	{
        float fog = (float )(1f-roomM.getRoomInfo().containerInfo.remainingFogPrecentage);
        //print("fog value is  " + fog);
        fog = Mathf.Clamp(fog, 0.1f, 0.8f);
        currentIntensity= fog; //= 1f-normalizeValueInRange(roomM.getRoomInfo().containerInfo.remainingFogPrecentage);
        //print("currentIntensity is: " +currentIntensity);
    }

    public void resetLightingToRoomCurrent(float roomCurrent)
	{
        light.intensity = roomCurrent;
	}

    public float getIntensity() => light.intensity;
}
