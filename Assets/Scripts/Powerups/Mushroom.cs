using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mushroom :  PowerupBase
{
    override public PowerupInfo getPowerupInfo()
	{
        return new PowerupInfo("Mushroom", "AttributeModifier","EnlargeWeapon", "Makes the weapon huge!");
	}
}
