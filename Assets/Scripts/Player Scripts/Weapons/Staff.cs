using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Timer))]
public class Staff : MonoBehaviour, IWeapon
{
    Timer[] timers;

    [SerializeField] float damage;
    [SerializeField] float framesPerSecond;
    [SerializeField] float[] attackDurationInFrames;
    [SerializeField] int maxComboCount;
    [SerializeField] float pushbackForce;

    CapsuleCollider hitbox;

    int currentComboCount;
    float attackStartTime;
    bool attackRequested;
    bool canHit;
    bool attacking;
    int direction;

    // Start is called before the first frame update
    void Awake()
	{
        timers = GetComponents<Timer>();
        hitbox = GetComponent<CapsuleCollider>();

        currentComboCount = 0;
        attackRequested = false;
        attacking = false;
	}


    public int getCurrentComboHit() => currentComboCount;

    public void requestNextAttack()
    {
        if (currentComboCount > 0)
            attackRequested = true;

        else
            attack();
    }

    public void attack()
    {

        /*
         * maxComboCounter defines how many hits the combo has.
         * if the currentComboCount is not maxed out and the maximum delay between
         * hits was not reached, attack again and reset delay to 0.
         * 
         */

        hitbox.enabled = false;

        if (currentComboCount <= maxComboCount) 
        {
            currentComboCount++;

            if (currentComboCount > maxComboCount)
            {
                currentComboCount = 0;
                return;
            }

            float animationLengthInSeconds = attackDurationInFrames[currentComboCount-1] / framesPerSecond;
            timers[1].setParameters(animationLengthInSeconds - 0.1f, simulateAttack);
            timers[1].fire();
            attacking = true;
            

            timers[0].setParameters(animationLengthInSeconds, decideWhatsNext);
            timers[0].fire();

            attackRequested = false;
        }
    }

    public bool isAttacking()
	{
        if (attacking)
		{
            attacking = false;
            return true;
		}
        return false;
	}

    void simulateAttack() => hitbox.enabled = true;

    void decideWhatsNext()
    {
        if (attackRequested)
        {   attack();   }

        else
        {
            hitbox.enabled = false;
            currentComboCount = 0;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy") && collision.isTrigger==false)
		{
            IVulnrable enemy = collision.GetComponent<IVulnrable>();
            Vector3 pushback = new Vector3(transform.localScale.x, 0, 0);
            enemy?.takeDamage(pushback*pushbackForce, damage);
		}
    }

    public void getChapiDirection()
	{

	}
    
    }

