using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : PowerupBase
{
    [SerializeField] int recoveredHealthAmount;
	public override PowerupInfo getPowerupInfo()
	{
        return new PowerupInfo("Health Pickup", "Consumable", "RecoverHealth", "Recovers a set amount of health.");
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
