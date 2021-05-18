using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //The point of this class is to find the game manager
    //during runtime and assign the moving function.

    GameManager manager;
    Button button;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(manager.moveToFirstLevel);
    }

    void Update()
    {
        
    }
}
