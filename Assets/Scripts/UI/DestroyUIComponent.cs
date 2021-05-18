using UnityEngine;

[RequireComponent(typeof(Timer))]
public class DestroyUIComponent : MonoBehaviour
{
    Timer timer;
    [SerializeField] float duration;
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.setParameters(duration,destroy);
        timer.fire();
    }

    void Update()
    {
        
    }

    void destroy()
	{
        Destroy(gameObject);
	}
}
