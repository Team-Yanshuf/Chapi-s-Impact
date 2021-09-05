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
		FogContainer.FogDwindledEventHandler += onPollutionDwindled;
	}

    void onPollutionDwindled(float i_FogDwindled)
    {
        float fog = Mathf.Clamp(i_FogDwindled, 0.1f, 0.8f);
        currentIntensity = fog; 
        light.intensity = currentIntensity;
    }

    public void resetLightingToRoomCurrent(float roomCurrent)
	{
        light.intensity = roomCurrent;
	}

    public float getIntensity() => light.intensity;
}
