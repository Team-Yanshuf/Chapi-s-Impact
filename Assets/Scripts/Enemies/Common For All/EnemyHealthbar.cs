using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    Image healthbar;
    //IHealthManager HPM;
    float maxHealth;
    float currentHealth;
    float healthPrecentage;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = transform.Find("Foreground").GetComponent<Image>();
 
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //setCurrentHP();
        updateBar();
    }

    void setMaxHP(float hp) => maxHealth = hp;
    //void setCurrentHP(float hp) => currentHealth = hp;
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
