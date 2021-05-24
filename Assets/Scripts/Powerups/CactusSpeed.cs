using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSpeed : PowerupBase
{
	public override PowerupInfo getPowerupInfo()
	{
        return new PowerupInfo("CactusSpeed", "StatModifier", "SpeedUp", "Increases movement speed!");
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
