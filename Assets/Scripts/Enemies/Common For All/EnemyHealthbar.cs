using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    Image healthbar;
    float maxHealth;
    float currentHealth;
    float healthPrecentage;

    void Start()
    {
        healthbar = transform.Find("Foreground").GetComponent<Image>();
    }

    private void LateUpdate()
    {
        updateBar();
    }

    public void setCurrentHP(float hp)
    {
        int delta = (int)(currentHealth - hp);
        StartCoroutine(set());
        IEnumerator set()
        {
            while (currentHealth > hp)
            {
                currentHealth -= delta / 4;
                yield return null;
            }
        }
    }

    public void updateBar()
    {
        healthPrecentage = (float)currentHealth / (float)maxHealth;
        healthbar.fillAmount = healthPrecentage;
    }

    public void initBar(float hp)
    {
        maxHealth = hp;
        currentHealth = hp;
    }
}
