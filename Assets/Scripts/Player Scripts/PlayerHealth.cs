using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] float invincibilityDuration;
    [SerializeField] float flashingDelta;
    bool isInvincible;
    Player playerM;

    void Start()
    {
        playerM = GetComponent<Player>();

        isInvincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkHpStatus();
    }

    public void lowerHealthBy(float damage)
	{
        if (isInvincible)
        {
            //Do nothing for now.
        }
        else
        {
            hp -= (int)damage;
            isInvincible = true;
            StartCoroutine(becomeInvincible(invincibilityDuration));
        }

	}

    private void checkHpStatus()
    {
        if (hp<=0)
        {
            playerM.die();
        }
    }

    IEnumerator becomeInvincible(float duration)
    {
        Debug.Log("Chappi is invincible!");
        bool enabled = true;
        for (float i =0; i<duration; i+=flashingDelta)
        {
            playerM.setRendererEnabled(enabled);
            enabled = !enabled;
            yield return new WaitForSeconds(flashingDelta);
        }

        playerM.setRendererEnabled(true);

        isInvincible = false;
        Debug.Log("NO LONGER INVINCIBLE!");
    }

}
