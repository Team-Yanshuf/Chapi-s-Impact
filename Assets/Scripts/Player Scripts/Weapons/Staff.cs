using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Timer))]
public class Staff : MonoBehaviour, IWeapon
{
    Timer timer;
    bool canHit;
    [SerializeField] float damage;
    [SerializeField] float attackDuration;
    [SerializeField] float attackFrameWindow;
    [SerializeField] int maxComboCount;
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
        timer.setParameters(attackDuration, turnOff);
        timer.fire();
        /*
         * maxComboCounter defines how many hits the combo has.
         * if the currentComboCount is not maxed out and the maximum delay between
         * hits was not reached, attack again and reset delay to 0.
         * 
         */
       // Debug.Log("startTime: " + (attackStartTime+attackDuration)  + "\trealTime: " + Time.realtimeSinceStartup);

         if (currentComboCount < maxComboCount) 
        {
            Debug.Log("Attack number: " + currentComboCount);
            simulateAttack();
            currentComboCount++;
            if (currentComboCount >= maxComboCount)
                currentComboCount = 0;
        }

    }

    void simulateAttack()
    {    hitbox.enabled = true;    }

    void turnOff()
    {
        hitbox.enabled = false;
        currentComboCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other is IVulnrable)
        {
            IVulnrable enemy = other as IVulnrable;
            enemy.takeDamage();
        }

    }


    public int getCurrentComboHit() => currentComboCount;
    
    }

