using UnityEngine;


public struct WeaponInfo
{
	public WeaponCollisionInfo collisionI { get; }

	public WeaponInfo(WeaponCollisionInfo collisionI)
	{
		this.collisionI = collisionI;
	}
}
public class WeaponManager : MonoBehaviour
{
    PlayerInfo info;
	StaffAnimation animationM;
	WeaponSound soundM;
	WeaponCollision collisionM;
	Staff weapon;
	Player playerM;

	bool canUpdate;

    public void initSelf()
	{
		playerM = GetComponentInParent<Player>();
		weapon = GetComponent<Staff>();

		animationM = GetComponent<StaffAnimation>();
		animationM.initSelf();


		collisionM = GetComponentInChildren<WeaponCollision>();

		soundM = GetComponent<WeaponSound>();
		//soundM.initSelf();

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

	public WeaponInfo getWeaponInfo()
	{
		return new WeaponInfo(collisionM.getWeaponCollisionInfo());
	}

	public bool isAttacking() => weapon.isAttacking();

}
