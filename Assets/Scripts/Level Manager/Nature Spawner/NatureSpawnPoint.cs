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

	float currentFogPrecentage;
	bool rendererSet; //is the renderer sprite already set?
	bool fogDoneGenerating;
	NatureSpawner natureM;
	GameObject naturePiece;

	private void Start()
	{

	}

	public void initSelf(RoomInfo roomInfo)
	{
		natureM = transform.parent.GetComponentInParent<NatureSpawner>();
		setNaturePieceBasedOnType();
		naturePiece = Instantiate(naturePiece, transform.position, Quaternion.identity);
		NaturePiece piece = naturePiece.GetComponent<NaturePiece>();


		piece.setType(type);
		piece.initSelf();
		piece.setPrecent(precentage);
		piece.transform.SetParent(this.transform);
	}


		public bool isActive() => active;

		public NatureType getType() => type;

		public void setFogDone(bool done) => fogDoneGenerating = done;
		public void setFogState(float precentage)
		{
			currentFogPrecentage = precentage;
		if (active && fogDoneGenerating)
		{
			passCurrentStateToNaturePiece();
		}
	}

	internal void setRoomState(RoomInfo roomInfo)
	{
		//point.setFogDone(roomInfo.finishedLoading);
		//point.setFogState(roomInfo.containerInfo.remainingFogPrecentage);

		fogDoneGenerating = roomInfo.finishedLoading;
		currentFogPrecentage = roomInfo.containerInfo.remainingFogPrecentage;
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
			naturePiece.GetComponent<NaturePiece>().setCurrentFogState(currentFogPrecentage);
		}


	}