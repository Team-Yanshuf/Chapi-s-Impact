using UnityEngine;

public class OilMonsterCollision : MonoBehaviour, IVulnrable
{
    bool hurt = false;
    OilMonster monsterM;
    [SerializeField] float hp;
    [SerializeField] int damage;
    [SerializeField] float pushbackForce;

    void Start()
    {
        monsterM= GetComponent<OilMonster>();       
    }

    public void TakeDamageAndApplyPushBack(Vector3 pushback, float damage = 0)
    {
        hurt = true;
        monsterM.takeDamage(damage);
        monsterM.Pushback(pushback);
    }

  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            IVulnrable player = collision.gameObject.GetComponent<IVulnrable>();
            float sign= Mathf.Sign(collision.transform.position.x-transform.position.x);
            player?.TakeDamageAndApplyPushBack(transform.right*sign*pushbackForce, damage);
        }
    }

    public bool isHurt()
    {
        if (hurt)
        {
            return true;
        }
        return false;
    }

    //This is called by the hurt animation.
    public void setNotHurt() => hurt = false;

	public void ApplyPushBack(Vector3 i_Pushback = default)
	{
        monsterM.Pushback(i_Pushback);
	}
}
