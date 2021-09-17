using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCollision : MonoBehaviour, IVulnrable
{
	Wheel wheelM;
	[SerializeField] float damage;
	bool isReady = false;

	public void InitSelf()
	{
		wheelM = GetComponent<Wheel>();
		isReady = true;
	}

	void IVulnrable.ApplyPushBack(Vector3 i_Pushback)
	{
		throw new System.NotImplementedException();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (isReady)
		{
			if (collision.gameObject.CompareTag("Player"))
			{
				IVulnrable other = (IVulnrable)collision.gameObject.GetComponent<PlayerCollision>();
				other.TakeDamageAndApplyPushBack(Vector3.zero, damage);
			}
			
			else if (collision.gameObject.CompareTag("LevelBoundries"))
			{
				wheelM.ApplyPushback(-wheelM.GetWheelMovementInfo().DirectionVector.normalized*10);
				wheelM.GetWheelEvents().OnWheelCollidedWithWall();
			}

		}

	}

	void IVulnrable.TakeDamageAndApplyPushBack(Vector3 i_Pushback, float i_Damage)
	{
		wheelM.TakeDamage(i_Damage);
		wheelM.ApplyPushback(i_Pushback);
	}
}
