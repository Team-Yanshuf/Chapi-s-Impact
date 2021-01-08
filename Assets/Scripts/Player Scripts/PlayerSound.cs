using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    Player playerM;

    [SerializeField] AudioSource footSteps;
    [SerializeField] AudioSource hurt;
    [SerializeField] AudioSource attack;
    [SerializeField] AudioSource collect;




    // Start is called before the first frame update
    void Start()
    {
        playerM = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        playFootSetps();
    }

    void playFootSetps()
    {
        if (!footSteps)
            return;

        else if  (playerM.isMoving() && !footSteps.isPlaying)
        {
            footSteps.Play();
        }
    }

    void playCollect()
    {
        if (!collect)
            return;

        if (playerM.isCollecting())
            collect.Play();
            
    }
}
