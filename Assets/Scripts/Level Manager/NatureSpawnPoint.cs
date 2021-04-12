using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NatureType
{
	BUSH,
	GRASS,
	TREE,
	DEER
}

[RequireComponent(typeof(SpriteRenderer))]
public class NatureSpawnPoint : MonoBehaviour
{

    [SerializeField] bool active; //Should this spawnpoint be used?
	[SerializeField] NatureType type;

	[Header("Make the sprite appear when fog reaches this %")]
	[SerializeField] [Range(0f, 100f)] float precentage;
	Sprite sprite;
	SpriteRenderer renderer;

	float currentFogState;
	bool rendererSet; //is the renderer sprite already set?
	bool fogDoneGenerating;

	private void Start()
	{
		renderer = GetComponent<SpriteRenderer>();
		renderer.enabled = false;
		setSpriteBasedOnType();
	}

	private void Update()
	{
		if (active && !rendererSet && fogDoneGenerating)
		{
			if (currentFogState <= precentage)
			{
				renderer.enabled = true;
				renderer.sprite = sprite;
				rendererSet = true;
			}
		}
	}

	public bool isActive() => active;

	public NatureType getType() => type;

	public void setFogDone(bool done) => fogDoneGenerating = done;
	public void setFogState(float precentage)
	{
		currentFogState = precentage;
	}
		void setSpriteBasedOnType()
	{
		switch(type)
		{
			case NatureType.BUSH:
				{
					sprite = Resources.Load<Sprite>("Nature/Bush");
					break;
				}

			case NatureType.TREE:
				{
					sprite = Resources.Load<Sprite>("Nature/Tree");
					break;
				}

			case NatureType.GRASS:
				{
					sprite = Resources.Load<Sprite>("Nature/Grass");
					break;
				}
		}
	}
}
