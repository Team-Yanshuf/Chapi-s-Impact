﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManagerEvents : MonoBehaviour
{
    GameManager manager;
    SceneManager sceneManager;
    /* PAUSE EVENT */
    //public delegate void Pause();
    //public static event Pause pause;

    //alternative
    public static UnityEvent pause = new UnityEvent();
    public static UnityEvent resume = new UnityEvent();
    public static UnityEvent enemyDefeated = new UnityEvent();
    public static UnityEvent chapiDied = new UnityEvent();
    public static UnityEvent treePlanted = new UnityEvent();


	public static void onPause() => pause?.Invoke();
    public static void onResume() => resume?.Invoke();
    public static void OnEnemyDefeated() => enemyDefeated?.Invoke();
    public static void onChapiDied() => chapiDied?.Invoke();
    public static void onTreePlanted() => treePlanted?.Invoke();
}
