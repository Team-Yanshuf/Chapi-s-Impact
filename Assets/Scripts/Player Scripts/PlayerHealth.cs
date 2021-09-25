using System.Collections;
using UnityEngine;


public struct PlayerHealthInfo
{
    public int maxHP { get; set; }
    public int currentHP { get; set; }

    public PlayerHealthInfo(int i_MaxHP, int i_CurrentHP)
	{
        maxHP = i_MaxHP;
        currentHP = i_CurrentHP;
	}
}
public class PlayerHealth : MonoBehaviour
{
    int currentHP;
    [SerializeField] int maxHP;
    [SerializeField] float invincibilityDuration;
    [SerializeField] float flashingDelta;

    bool dead = false;
    bool isInvincible;
    Player playerM;

    void Start()
    {
        playerM = GetComponent<Player>();
        currentHP = maxHP;
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
            currentHP -= (int)damage;
            isInvincible = true;
            StartCoroutine(becomeInvincible(invincibilityDuration));
        }

	}

    public void RecoverHealthBy(int i_HealthToAdd)
	{
        currentHP += i_HealthToAdd;
	}
    private void checkHpStatus()
    {
        if (currentHP<=0)
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

    public int getHP() => currentHP;

    public PlayerHealthInfo GetPlayerHealthInfo()
	{
        return new PlayerHealthInfo(maxHP, currentHP);
	}

}
