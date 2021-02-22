using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilMonsterSounds : MonoBehaviour
{
    OilMonster monsterM;
    [SerializeField] FMODUnity.StudioEventEmitter crawl;
    [SerializeField] FMODUnity.StudioEventEmitter hurt;
    // Start is called before the first frame update
    void Start()
    {
        monsterM = GetComponent<OilMonster>();

    }

    // Update is called once per frame
    void Update()
    {
        playMove();
        playHurt();
        
    }   
    void playMove()
    {
        if(monsterM.isCrawling() && !crawl.IsPlaying())
            {
                crawl.Play();
            }
                
        
    }
    void playHurt()
    {
        if (monsterM.isHurt() && !hurt.IsPlaying() )
        {
            hurt.Play();
        }
    }
}
