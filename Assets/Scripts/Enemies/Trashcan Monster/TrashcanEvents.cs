using UnityEngine;
using UnityEngine.Events;

public class TrashcanEvents : MonoBehaviour
{
    internal UnityEvent jump;
    internal UnityEvent land;

    public void initSelf()
	{
        jump = new UnityEvent();
        land = new UnityEvent();
	}


     //UnityEvent jump;
     //UnityEvent land;

 //   private void Awake()
 //   {
 //       jump = new UnityEvent();
 //       land = new UnityEvent();
 //   }

 //   private void Start()
 //   {
 //       print("Events are instantiated");
 //   }

 //   public  void invokeJumpEvent() => jump?.Invoke();
	//public  void invokeLandEvent() => land?.Invoke();
 //   public void addJumpListener(UnityAction call) => jump.AddListener(call);
 //   public void addLandListener(UnityAction call) => land.AddListener(call);
}
