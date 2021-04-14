using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    Image healthbar;
    int maxHealth;
    int currentHealth;
    float healthPrecentage;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = transform.Find("Foreground").GetComponent<Image>();   
    }

	// Update is called once per frame
	private void LateUpdate()
	{
		
	}



	void setCurrentAndMaxHealth(int maxHealth)
	{
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        
	}

    void updateBar()
	{
        healthPrecentage = (float)currentHealth / (float)maxHealth;
        healthbar.fillAmount = healthPrecentage;
    }

    void updateHealth()
}
