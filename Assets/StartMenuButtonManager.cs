using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuButtonManager : MonoBehaviour
{
    [SerializeField] Button start;
    [SerializeField] Button quit;

    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        start.onClick.AddListener(manager.moveToFirstLevel);
        quit.onClick.AddListener(manager.quit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
