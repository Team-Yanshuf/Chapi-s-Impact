using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
	bool started;
	float timeStarted;
	float timerDuration;
	Action action;
	

	public Timer(float timerDuration, Action action)
	{
		timeStarted = Time.realtimeSinceStartup;
		this.timerDuration = timerDuration;
		this.action = action;
		
	}

	private void Update()
	{
		if (started)
		tickTime();
	}

	public void tickTime()
	{
		if (timeStarted + timerDuration < Time.realtimeSinceStartup)
		{
			started = false;
			action.Invoke();
		}

	}

	public void setParameters(float timerDuration, Action action)
	{
		this.timerDuration = timerDuration;
		this.action = action;
	}

	public void fire()
	{
		started = true;
		this.timeStarted = Time.realtimeSinceStartup;
	}





}
