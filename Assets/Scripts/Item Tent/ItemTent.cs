using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct ItemTentInfo
{
	public bool isHurt;

	public ItemTentInfo(bool isHurt)
	{
		this.isHurt = isHurt;
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

	ItemTentInfo info;

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
		itemM.spawnItem();
		Destroy(this.gameObject);
	}

	public ItemTentInfo getTentInfo()
	{
		return new ItemTentInfo(collisionM.getIsHurt());
	}
}
