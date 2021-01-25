using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour, IVulnrable
{
    OilMonster monsterM;

    // Start is called before the first frame update
    void Start()
    {
        monsterM= GetComponent<OilMonster>();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage=0)
    {

    }
}
