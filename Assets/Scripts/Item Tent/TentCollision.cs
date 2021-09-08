using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentCollision : MonoBehaviour, IVulnrable
{
    ItemTent tentM;
	bool isHurt;

	public void initSelf()
	{
		isHurt = false;
		tentM = GetComponent<ItemTent>();
	}
	public void TakeDamageAndApplyPushBack(Vector3 pushback = default, float damage = 0)
	{
		isHurt = true;
		tentM.takeDamage(20);
	}

	public bool getIsHurt()
	{
		if (isHurt)
		{
			isHurt = false;
			return true;
		}
		return false;
	}

	public void ApplyPushBack(Vector3 i_Pushback = default)
	{
		//Should not apply pushback.
		throw new System.NotImplementedException();
	}
}
