using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    int health;
    Player player;
    Image image;
    float interpolator;
    Vector3 target;
    Vector3 initial;
    
    public void InitSelf()
	{
        interpolator = 0f;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        health = player.getHP();
        print(health);
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
        if (health != player?.getHP())
            StartCoroutine(updateFlask());
	}

    IEnumerator updateFlask()
	{
        int maxHealth = player.GetPlayerHealthInfo().maxHP;
        int difference = health - (int)player?.getHP();
        health = (int)player?.getHP();
        for (int i=0; i<difference; i++)
		{
            interpolator += 1f / maxHealth;
            image.rectTransform.localPosition = Vector3.Lerp(initial, target, interpolator);

            yield return null;
		}

	}

}
