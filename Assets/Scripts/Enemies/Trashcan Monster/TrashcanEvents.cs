﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TrashcanEvents : MonoBehaviour
{
    internal static UnityEvent jump = new UnityEvent();
    internal static UnityEvent land = new UnityEvent();




     //UnityEvent jump;
     //UnityEvent land;

 //   private void Awake()
 //   {
 //       jump = new UnityEvent();
 //       land = new UnityEvent();
 //   }

 //   private void Start()
 //   {
 //       print("Events are instantiated");
 //   }

 //   public  void invokeJumpEvent() => jump?.Invoke();
	//public  void invokeLandEvent() => land?.Invoke();
 //   public void addJumpListener(UnityAction call) => jump.AddListener(call);
 //   public void addLandListener(UnityAction call) => land.AddListener(call);
}
