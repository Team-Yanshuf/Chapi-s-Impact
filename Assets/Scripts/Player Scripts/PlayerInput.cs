using UnityEngine;

public class PlayerInput : MonoBehaviour
{

	Player playerM;
	float horizontal, vertical;
	float groundRotation;
	public LayerMask layerToIgnore;

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
			
			return ((hit.point+hit.normal*2)-transform.position);
		}
		return Vector3.zero;
		//return Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;

	}

	public bool meleePressed()
	{
		if (Input.GetMouseButtonDown(0))
			return true;
		return false;
	}

	public bool shootPressed()
	{
		if (Input.GetMouseButtonDown(1))
			return true;
		return false;
	}

	public bool dashPressed()
	{
		return Input.GetAxis("Dash") > 0.95f;
	}

	public bool plantingPressed()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			return true;
		}
		return false;
	}
}
