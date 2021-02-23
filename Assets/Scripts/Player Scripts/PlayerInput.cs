using UnityEngine;

public class PlayerInput : MonoBehaviour
{

	Player playerM;
	float horizontal, vertical;
	float groundRotation;

	bool dashInUse = false, meleeInUse = false;

	void Start()
	{
		playerM = GetComponent<Player>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void getMovementAxes(ref float horizontal,ref float vertical)
	{
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");
	}

	public Vector3 getMouseAimDirectionNormalized()
	{
		RaycastHit hit;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
		{
			Debug.DrawRay(hit.point, hit.normal, Color.yellow,5f);
			
			return ((hit.point+hit.normal)-transform.position);
		}
		return Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;

	}

	public bool meleePressed()
	{
		if (!meleeInUse)
		{
			meleeInUse = true;
			return Input.GetAxis("Melee") > 0.95f;

		}

		else if (Input.GetAxis("Melee") == 0)
		{
			meleeInUse = false;
		}

		return false;
	}

	public bool dashPressed()
	{
		return Input.GetAxis("Dash") > 0.95f;
	}
}
