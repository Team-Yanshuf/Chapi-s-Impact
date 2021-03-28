using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanAttacking : MonoBehaviour
{

    Trashcan enemyM;
    bool attacking = false;

    [SerializeField] CigaretteParticle cig;
    // Start is called before the first frame update
    void Start()
    {
        enemyM= GetComponent<Trashcan>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (enemyM.canAttackBasedOnLands())
        //{
        //   // attack();
        //    attacking = true;
        //}
    }

    public bool isAttacking() => attacking;


    void attack()
    {
        StartCoroutine(spawnCigaretteParticles());
    }

    IEnumerator spawnCigaretteParticles()
    {
        int amount = Random.Range(3, 9);

        for (int i=1; i<amount*2; i++)
        {
            print(i);
            if (i%2==0)
            Instantiate<CigaretteParticle>(cig, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            yield return null;
        }
        attacking = false;
    }

    internal void approveAttack()
    {
        attacking = true;
    }
}
