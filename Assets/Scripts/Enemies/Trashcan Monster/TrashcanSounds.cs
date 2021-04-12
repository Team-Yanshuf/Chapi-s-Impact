using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanSounds : MonoBehaviour
{
    Trashcan trashM;

    [SerializeField] FMODUnity.StudioEventEmitter move;
    [SerializeField] FMODUnity.StudioEventEmitter attack;
    [SerializeField] FMODUnity.StudioEventEmitter hurt;
    [SerializeField] FMODUnity.StudioEventEmitter die;
    // Start is called before the first frame update
    void Start()
    {
        trashM = GetComponent<Trashcan>();
    }

    // Update is called once per frame
    void Update()
    {
        playMove();
        playAttack();
        playHurt();
    }

    public void playDie() => die?.Play();
    void playMove()
	{
        if (trashM.isMoving())
            move?.Play();
	}

    void playAttack()
	{
        if (trashM.isAttacking())
            attack?.Play();
	}

    void playHurt()
	{
        if (trashM.isHurt())
            hurt?.Play();
	}

}
