using UnityEngine;

public class CigaretteParticle : MonoBehaviour
{
	Rigidbody rb;
	[SerializeField] int min, max;

	void Start()
	{
		rb = GetComponent<Rigidbody>();

		Vector3 trajectory = generateRandomVector();
		Vector3 grav = -Physics.gravity;

		rb.AddForce(grav + trajectory, ForceMode.Impulse);
	}


	Vector3 generateRandomVector()
    {

		System.Random rand = new System.Random();
		if (min == 0 && max == 0)
			return new Vector3(rand.Next(-5, 5), rand.Next(-5, 5), rand.Next(-5, 5));
		else
			return new Vector3(rand.Next(min, max), rand.Next(min, max), rand.Next(min, max));
    }



}
