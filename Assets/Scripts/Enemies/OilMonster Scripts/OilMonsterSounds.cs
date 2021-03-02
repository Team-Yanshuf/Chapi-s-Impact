using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilMonsterSounds : MonoBehaviour
{
    OilMonster monsterM;
    [SerializeField] FMODUnity.StudioEventEmitter move;
    [SerializeField] FMODUnity.StudioEventEmitter hurt;
    [SerializeField] FMODUnity.StudioEventEmitter die;
  
    void Start()
    {
        monsterM = GetComponent<OilMonster>();
    }

    void Update()
    {
        playMove();
        playHurt(); 
    }   
    void playMove()
    {
        if (!move)
            return;

        if(monsterM.isCrawling() && !move.IsPlaying())
            {
                move.Play();
            } 
    }
    void playHurt()
    {
        if (!hurt)
            return;

        if (monsterM.isHurt() && !hurt.IsPlaying() )
        {
            hurt.Play();
        }
    }
    public void playDie() => die?.Play();
}