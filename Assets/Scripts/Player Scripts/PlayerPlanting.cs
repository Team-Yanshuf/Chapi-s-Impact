using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlanting : MonoBehaviour
{
    bool planting = false;
    [SerializeField] Tree tree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isPlanting() => planting;

    void plant()
	{
        Instantiate(tree, transform.position + new Vector3(5, 0, 0), Quaternion.identity);
	}
}
