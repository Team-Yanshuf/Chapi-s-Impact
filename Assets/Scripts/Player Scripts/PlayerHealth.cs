using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int hp;
    [SerializeField] int maxHP;
    [SerializeField] float invincibilityDuration;
    [SerializeField] float flashingDelta;

    bool dead = false;
    bool isInvincible;
    Player playerM;

    void Start()
    {
        playerM = GetComponent<Player>();
        hp = maxHP;
        isInvincible = false;
    }

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

    public void RecoverHealthBy(int i_HealthToAdd)
	{
        hp += i_HealthToAdd;
	}
    private void checkHpStatus()
    {
        if (hp<=0)
        {
            dead = true;
            playerM.die();
        }
    }

    public bool isDead()
	{
        if (dead)
		{
            dead = false;
            return true;
		}
        return false;
	}

    IEnumerator becomeInvincible(float duration)
    {
        bool enabled = true;
        for (float i =0; i<duration; i+=flashingDelta)
        {
            playerM.setRendererEnabled(enabled);
            enabled = !enabled;
            yield return new WaitForSeconds(flashingDelta);
        }

        playerM.setRendererEnabled(true);

        isInvincible = false;
    }

    public int getHP() => hp;

}
