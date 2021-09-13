using UnityEngine;

public class OilMonster : MonoBehaviour, IEnemy
{
    [SerializeField] GameObject target;

    OilMonsterAnimation animationM;
    OilMonsterSounds soundM;
    WormChasePlayer movementM;
    EnemyAgro agroM;
    OilMonsterHealth healthM;
    OilMonsterCollision collisionM;
	RoomEvents currentRoomEvents;

	void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        initializeComponents();

        healthM.initHP(100);
    }

    internal void Pushback(Vector3 pushback) => movementM.pushback(pushback);
	public Vector3 getTargetPosition()
    {
        if (target)
            return target.transform.position;
        return transform.position;
    }

	internal void takeDamage(float damage)
	{
        healthM.reductHP(damage);
	}

	public bool isCrawling()
    {
        if (!animationM)
        {
            Debug.Log("No animation handler ");
            return false;
        }

         return animationM.isInActiveCrawl();
    }
    public bool isHurt() => collisionM.isHurt();
    public bool isAgroed() => agroM.isAgroed();
    public void die()
	{
        soundM.playDie();
        currentRoomEvents.dwindleLocalFog.Invoke();
        Destroy(this.gameObject);
	}
    void initializeComponents()
	{
        collisionM = GetComponent<OilMonsterCollision>();
        movementM = GetComponent<WormChasePlayer>();
        animationM = GetComponent<OilMonsterAnimation>();
        agroM = GetComponent<EnemyAgro>();
        soundM = GetComponent<OilMonsterSounds>();
        healthM = GetComponent<OilMonsterHealth>();
    }

	public void setRoomEvents(RoomEvents roomEvents)
	{
        this.currentRoomEvents = roomEvents;
	}
}