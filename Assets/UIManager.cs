using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    UICanvas canvas;
    void Start()
    {
        canvas = GetComponentInChildren<UICanvas>();
        canvas.InitSelf();
    }
}
