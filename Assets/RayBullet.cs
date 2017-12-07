using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBullet : IBullet
{
    public int DamageDone()
    {
        return FlyWeightPointer.rayDamage;
    }

    public float LifeSpan()
    {
        return FlyWeightPointer.rayLifeSpan;
    }

    public bool NeedToDestroy()
    {
        return false;
    }

    public void OnHit(Collider c)
    {
        if (c.GetComponent(typeof(Enemy)))
            ((Entity)c.GetComponent(typeof(Entity))).TakeDamage(FlyWeightPointer.rayDamage);
    }

    public float Speed()
    {
        return FlyWeightPointer.raySpeed;
    }
}
