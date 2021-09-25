using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    int currentHealth;
    Player player;
    Image image;
    float interpolator;
    Vector3 target;
    Vector3 initial;

    
    public void InitSelf()
	{
        interpolator = 0f;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currentHealth = player.getHP();
        print(currentHealth);
        image = GetComponentsInChildren<Image>()[2];
        initial = image.rectTransform.localPosition;
        target = new Vector3(initial.x, initial.y - 4f, initial.z);
    }

    void Update()
    {
        triggerFlaskReduction();
    }

	private void triggerFlaskReduction()
	{
        if (currentHealth != player?.getHP())
            StartCoroutine(updateFlask());
	}

    IEnumerator updateFlask()
	{
        PlayerHealthInfo info = player.GetPlayerHealthInfo();
        int maxHealth = info.maxHP;
        int currentHealthFromPlayer = info.currentHP;

        int differenceFromPreviousAmountOfHealth = currentHealth - currentHealthFromPlayer;
        currentHealth = currentHealthFromPlayer;

        for (int i=0; i<differenceFromPreviousAmountOfHealth; i++)
		{
            image.rectTransform.localPosition = Vector3.Lerp(initial, target, interpolator);
            interpolator += 1f / maxHealth;
            yield return null;
		}

	}

}
