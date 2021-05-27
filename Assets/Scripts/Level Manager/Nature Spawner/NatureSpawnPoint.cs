using System;
using UnityEngine;

public enum NatureType
{
	ROCK1,
	ROCK2,
	ROCK3,
	TREE1
}

[RequireComponent(typeof(SpriteRenderer))]
public class NatureSpawnPoint : MonoBehaviour
{
	[Header("Is this spawn point active?")]
	[SerializeField] bool active; //Should this spawnpoint be used?
	[Header("What type of nature should grow here?")]
	[SerializeField] NatureType type;

	[Header("Make the sprite appear when fog reaches this %")]
	[SerializeField] [Range(0f, 100f)] float precentage;
	//Sprite sprite;
	//SpriteRenderer renderer;

	float currentFogState;
	bool rendererSet; //is the renderer sprite already set?
	bool fogDoneGenerating;


	GameObject naturePiece;



	private void Start()
	{
		setNaturePieceBasedOnType();
		naturePiece = Instantiate(naturePiece, transform.position, Quaternion.identity);
		naturePiece.GetComponent<NaturePiece>().setPrecent(precentage);


		naturePiece.GetComponent<NaturePiece>().setType(type);
		naturePiece.GetComponent<NaturePiece>().initSelf();
		//naturePiece.GetComponent<NaturePiece>().
	}

		private void Update()
		{
			if (active && fogDoneGenerating)
			{
			print("Fog finished "  + fogDoneGenerating	);
			passCurrentStateToNaturePiece();



			//if (currentFogState <= precentage)
			//{
			//	renderer.enabled = true;
			//	renderer.sprite = sprite;
			//	rendererSet = true;
			//}
		}
		}

		public bool isActive() => active;

		public NatureType getType() => type;

		public void setFogDone(bool done) => fogDoneGenerating = done;
		public void setFogState(float precentage)
		{
			currentFogState = precentage;
		}

		void setNaturePieceBasedOnType()
		{
			switch (type)
			{
				case NatureType.ROCK1:
					{
						naturePiece = Resources.Load<GameObject>("Nature/Rock1");

						break;
					}

				case NatureType.ROCK2:
					{
						naturePiece = Resources.Load<GameObject>("Nature/Rock2");
						break;
					}

				case NatureType.ROCK3:
					{
						naturePiece = Resources.Load<GameObject>("Nature/Rock3");
						break;
					}
				case NatureType.TREE1:
					{
						naturePiece = Resources.Load<GameObject>("Nature/Tree1");
						break;
					}
			}
			
		}

		void passCurrentStateToNaturePiece()
		{
			naturePiece.GetComponent<NaturePiece>().setCurrentFogState(currentFogState);
		}

	}