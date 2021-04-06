using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanAttacking : MonoBehaviour
{

    Trashcan enemyM;
    bool attacking = false;

    [SerializeField] CigaretteParticle particle;

    [Header("Range of particles to spawn")]
    [SerializeField] int min;
    [SerializeField] int max;

    void Start()
    {
        enemyM= GetComponent<Trashcan>();
    }
    public bool isAttacking() => attacking;

    void attack()
    {
        StartCoroutine(spawnCigaretteParticles());
    }

    IEnumerator spawnCigaretteParticles()
    {
        int amount = Random.Range(min, max);

        Vector3 offset = new Vector3(0, 3, 0);
        Vector3 spawnPosition = transform.position + offset;
        for (int i=0; i<amount*3; i++)
        {
            if (i%3==0)
            Instantiate<CigaretteParticle>(particle, spawnPosition , Quaternion.identity).transform.SetParent(this.transform);
            yield return null;
        }
        attacking = false;
    }

    internal void approveAttack()
    {
        attacking = true;
    }
}
