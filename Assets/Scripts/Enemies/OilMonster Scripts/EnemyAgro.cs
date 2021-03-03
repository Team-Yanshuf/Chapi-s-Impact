using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class EnemyAgro : MonoBehaviour
{
	[SerializeField] bool deAgroed;
    bool agroed = false;


	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player"))
        agroed = true;
	}


	private void OnTriggerExit(Collider other)
	{
		if (deAgroed)
        agroed = false;
	}

    public bool isAgroed() => agroed;
}
