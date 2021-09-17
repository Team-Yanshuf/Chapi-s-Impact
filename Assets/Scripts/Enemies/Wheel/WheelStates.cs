using UnityEngine;

public struct WheelStatesInfo
{
    public bool Idle { get; set; }
    public bool Starting { get; set; }
    public bool Sprinting { get; set; }
    public bool Paralyzed { get; set; }

    public WheelStatesInfo(bool i_Idle, bool i_Starting, bool i_Sprinting, bool i_Paralyzed)
	{
        Idle = i_Idle;
        Starting = i_Starting;
        Sprinting = i_Sprinting;
        Paralyzed = i_Paralyzed;
	}

    public override string ToString()
	{
        return $"Idle: {Idle}, Starting: {Starting}, Sprinting: {Sprinting}, Paralyzed: {Paralyzed}";
	}
}

public class WheelStates : MonoBehaviour
{
    Wheel wheelM;

    private bool m_Idle;
    private bool m_Starting;
    private bool m_Sprinting;
    private bool m_Paralyzed;

    public void InitSelf()
	{
        wheelM = GetComponent<Wheel>();
        m_Idle = false;
        m_Starting = false;
        m_Sprinting = false;
        m_Paralyzed = false;
        initEventListeners();
	}

    private void initEventListeners()
	{
        WheelEvents eventsM = GetComponent<WheelEvents>();
        eventsM.wheelIdle.AddListener(onIdle);
        eventsM.wheelStarted.AddListener(onStarting);
        eventsM.wheelSprint.AddListener(onSprinting);
        eventsM.wheelCollidedWithWall.AddListener(onParalyzed);
	}
    
    public WheelStatesInfo GetWheelStateInfo()
	{
        return new WheelStatesInfo(m_Idle, m_Starting, m_Sprinting, m_Paralyzed);
	}

    private void onIdle()
	{
        m_Idle = true;
        m_Starting = false;
        m_Sprinting = false;
        m_Paralyzed = false;
    }

    private void onStarting()
	{
        m_Idle = false;
        m_Starting = true;
        m_Sprinting = false;
        m_Paralyzed = false;
    }

    private void onSprinting()
	{
        m_Idle = false;
        m_Starting = false;
        m_Sprinting = true;
        m_Paralyzed = false;
    }

    private void onParalyzed()
	{
        m_Idle = false;
        m_Starting = false;
        m_Sprinting = false;
        m_Paralyzed = true;
    }
}
