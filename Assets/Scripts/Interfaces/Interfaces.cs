using UnityEngine;
using System;
public interface IHitter
{
    void hit();
    void hit(int damage=0);
}

public interface IVulnrable
{
    void TakeDamageAndApplyPushBack(Vector3 i_Pushback= default(Vector3), float i_Damage = 0 );
    void ApplyPushBack(Vector3 i_Pushback = default(Vector3));
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