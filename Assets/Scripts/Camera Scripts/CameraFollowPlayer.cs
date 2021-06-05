using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    GameObject player;
    [SerializeField] float zOffset;
    [SerializeField] float yOffset;
    Vector3 position;

    [SerializeField] bool canFollow;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
            return;


        if (player.GetComponent<Player>().getPlayerInfo().isControlledByPlayer)
        if (canFollow)
		{
            position = player.transform.position - new Vector3(0, yOffset, zOffset);
            transform.position = position;
        }

    }
}

