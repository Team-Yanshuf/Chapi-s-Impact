using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    PlayerInfo info;
	StaffAnimation animationM;
	Player playerM;
	bool canUpdate;

    public void initSelf()
	{
		playerM = GetComponentInParent<Player>();
		animationM = GetComponent<StaffAnimation>();
		animationM.initSelf();
		canUpdate = true;
	}

	private void Update()
	{
		if (canUpdate)
		{
			info = playerM.getPlayerInfo();
			animationM.setPlayerInfo(info);
		}
	}
	public void updatePlayerInfo(PlayerInfo info)
	{
		this.info = info;
	}
}
