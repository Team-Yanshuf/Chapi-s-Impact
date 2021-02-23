using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Timer))]
public class Staff : MonoBehaviour, IWeapon
{
    Timer timer;
    bool canHit;
    [SerializeField] float damage;
    [SerializeField] float framesPerSecond;
    [SerializeField] float[] attackDurationInFrames;
    [SerializeField] int maxComboCount;

    bool attackRequested = false;




    int currentComboCount = 0;
    float attackStartTime;
    CapsuleCollider hitbox;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        hitbox = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame

    public void attack()
    {
        /*
         * maxComboCounter defines how many hits the combo has.
         * if the currentComboCount is not maxed out and the maximum delay between
         * hits was not reached, attack again and reset delay to 0.
         * 
         */
       // Debug.Log("startTime: " + (attackStartTime+attackDuration)  + "\trealTime: " + Time.realtimeSinceStartup);

         if (currentComboCount <= maxComboCount) 
        {
            currentComboCount++;

            if (currentComboCount > maxComboCount)
            {
                currentComboCount = 0;
                return;
            }

            Debug.Log("Attack number: " + currentComboCount);
            float animationLengthInSeconds = attackDurationInFrames[currentComboCount-1] / framesPerSecond;
            timer.setParameters(animationLengthInSeconds, decideWhatsNext);
            timer.fire();



            simulateAttack();

            attackRequested = false;
        }
    }

    void simulateAttack()
    {    hitbox.enabled = true;    }

    void decideWhatsNext()
    {
        if (attackRequested)
        {
            attack();
        }


        else
        {
            hitbox.enabled = false;
            currentComboCount = 0;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision detected");
        if (collision is IVulnrable)
        {
            Debug.Log("Enemy Detected");
            IVulnrable enemy = collision as IVulnrable;
            enemy.takeDamage();
        }
    }
    

    public void requestNextAttack()
    {
        if (currentComboCount > 0)
            attackRequested = true;

        else
            attack();
    }

    public int getCurrentComboHit() => currentComboCount;
    
    }

