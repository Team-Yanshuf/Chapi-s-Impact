using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentAnimation : MonoBehaviour
{
    Animator animator;
	ItemTent tentM;
	bool ready = false;
	internal void initSelf()
	{
        animator = GetComponent<Animator>();
		tentM = GetComponent<ItemTent>();
		ready = true;
	}
	private void Update()
	{
		if (ready)
		{
			setTentAnimationStates(tentM.getTentInfo());
		}
	}
	public void setTentAnimationStates(ItemTentInfo info)
	{
		if (info.collapsed)
		{
			print("collapsed state");
			animator.SetBool("Collapsed", true);
			ready = false;
		}
		else if (info.isHurt)
		{
			print("hurt state");
			animator.SetBool("Hurt", info.isHurt);
			animator.SetBool("Hurt", false);
		}

	}
}
