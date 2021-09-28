using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    HealthBar bar;
    
    public void InitSelf()
	{
        bar = GetComponentInChildren<HealthBar>();
        bar.InitSelf();
    }
  
}
