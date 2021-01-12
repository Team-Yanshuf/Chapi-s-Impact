using UnityEngine;

public class PlayerInput : MonoBehaviour
{

	Player playerM;
	float horizontal, vertical;
	float groundRotation;
	void Start()
	{
		playerM = GetComponent<Player>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void getAxes(ref float horizontal,ref float vertical)
	{
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
	}
	public Vector3 getMouseAimDirectionNormalized()
	{
		RaycastHit hit;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
		{
			return (transform.position - hit.normal);
		}
		return Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;

	}

	//Vector3 getMousePosInWorldCoordinates()
	//{
	//	Vector3 mousePosInPixels = Input.mousePosition;
	//	Vector3 newV = new Vector3(mousePosInPixels.x, mousePosInPixels.y, Camera.main.transform.position.z);


	//	return Camera.main.ScreenToWorldPoint(mousePosInPixels);

	// }

	//Vector3 getAdjustedMousePos()
	//{
	//	Vector3 mousePos = getMousePosInWorldCoordinates();
	//	return Vector3.zero;
	//}

	//Vector3 getProjecteMouseOnPlane()
	//{
	//	Ray ray = new Ray();
	//	ray.origin = getMousePosInWorldCoordinates();
	//	ray.direction = Vector3.forward;
	//	//if ()
	//	return Vector3.zero;
	//}

	//void drawAimRay()
	//{

	//	Quaternion angle = Quaternion.Euler(0, Mathf.Sin(Time.time), Mathf.Sin(Time.time));

	//	//	aimVector = angle * aimVector;
	//	Vector3 vec = angle * -aimVector;

	//	aimVector = Vector3.Lerp(aimVector, vec, t);



	//	//if (Input.GetKey(KeyCode.Space))
	//	//{
	//	//	aimVector.y = Mathf.Sin(Time.time);
	//	//	aimVector.z = -Mathf.Sin(Time.time);
	//	//}

	//	Debug.DrawRay(transform.position, aimVector*10f,Color.red);

	//}

	//void interpolate()
	//{
	//	Quaternion angle = Quaternion.Euler(groundRotation, 0, 0);
	//	Vector3 modifiedRight = angle * Vector3.right;
	//	Vector3 modifiedLeft = angle * Vector3.left; 
	//	Vector3 modifiedForward = angle * Vector3.forward;
	//	Vector3 modifiedBack = angle * Vector3.back;

	//	if (isSimilar(aimVector,modifiedRight))
	//	{

	//		t = 0;
	//		interpolator = modifiedBack;
	//	}


	//	else if (isSimilar(aimVector,modifiedBack))
	//	{
	//		t = 0;
	//		interpolator = modifiedLeft;
	//	}
	//	else if (isSimilar(aimVector ,modifiedLeft))
	//	{
	//		t = 0;
	//		interpolator = modifiedForward;
	//	}
	//	else if (isSimilar(aimVector,modifiedForward))
	//	{
	//		t = 0f;
	//		interpolator = modifiedRight;
	//	}

	//	aimVector = Vector3.Lerp(aimVector, interpolator, t);
	//	//if (Input.GetKey(KeyCode.Space))
	//		t += 0.1f;

	//	Debug.DrawRay(transform.position, aimVector*10f,Color.red);
	//}

	//bool isSimilar(Vector3 a, Vector3 b)
	//{
	//	float similarity = 0.1f;
	//	if (Mathf.Abs(b.x - a.x) < similarity && Mathf.Abs(b.y - a.y) < similarity && Mathf.Abs(b.z - a.z) < similarity)
	//		return true;
	//	return false;
	//}
}
