using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    Image healthbar;
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
        updateBar();
	}



	public void setCurrentAndMaxHealth(float maxHealth)
	{
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        
	}
    public void setCurrentHP(float hp)
	{
        currentHealth = hp;
	}

    public void updateBar()
	{
        healthPrecentage = (float)currentHealth / (float)maxHealth;
        healthbar.fillAmount = healthPrecentage;
    }

    void updateHealth()
	{

	}
}
