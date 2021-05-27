using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct ItemTentInfo
{
	public bool isHurt;
	public bool collapsed;

	public ItemTentInfo(bool isHurt, bool collapsed)
	{
		this.isHurt = isHurt;
		this.collapsed = collapsed;
	}
}

[RequireComponent(typeof(TentHealth))]
[RequireComponent(typeof(TentCollision))]
public class ItemTent : MonoBehaviour
{
    TentHealth healthM;
	TentCollision collisionM;
    ItemTent tent;
	TentItems itemM;
	TentAnimation animationM;

	bool collapsed;
	ItemTentInfo info;
	bool dead;

	private void Start()
	{
		healthM = GetComponent<TentHealth>();
		collisionM = GetComponent<TentCollision>();
		itemM = GetComponent<TentItems>();
		animationM = GetComponent<TentAnimation>();

		healthM.initSelf();
		collisionM.initSelf();
		itemM.initSelf();
		animationM.initSelf();
	}


	internal void takeDamage(int damage)
	{
		healthM.takeDamage(damage);
	}

	internal void die()
	{
		if (!collapsed)
		{
			Destroy(GetComponent<BoxCollider>());
			itemM.spawnItem();
			collapsed = true;
		}
	}

	public ItemTentInfo getTentInfo()
	{
		return new ItemTentInfo(collisionM.getIsHurt(),collapsed);
	}
}
