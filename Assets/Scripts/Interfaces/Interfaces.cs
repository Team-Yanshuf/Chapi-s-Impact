using UnityEngine;
using System;
public interface IHitter
{
    void hit();
    void hit(int damage=0);
}

public interface IVulnrable
{
    void takeDamage(Vector3 pushback= default(Vector3), float damage = 0 );
}

public interface ICollectible
{
    void collected();
}

public interface IEnemy
{
    void setRoomEvents(RoomEvents roomEvents);
}

public interface IWeapon
{
    void requestNextAttack();
    int getCurrentComboHit();
    bool isAttacking();
}

public interface IHealthManager
{
    float getCurrentHP();
    float getMaxHP();
}

public interface IPowerup
{
    string[] getPowerupFunctionality();
}