using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitter
{
    void hit();
    void hit(int damage=0);
}

public interface IVulnrable
{
    void takeDamage(Vector3 pushback, float damage = 0 );
}

public interface ICollectible
{
    void collected();
}

public interface IWeapon
{
    void requestNextAttack();
    int getCurrentComboHit();
    bool isAttacking();
}





