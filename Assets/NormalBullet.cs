using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : IBullet {

    public int DamageDone()
    {
        return FlyWeightPointer.bulletDamage;
    }

    public float LifeSpan()
    {
        return FlyWeightPointer.bulletLifeSpan;
    }

    public bool NeedToDestroy()
    {
        return true;
    }

    public void OnHit(Collider c)
    {
       // if (c.GetComponent(typeof(Enemy)))
        //    ((Entity)c.GetComponent(typeof(Entity))).TakeDamage(FlyWeightPointer.bulletDamage);
        
    }

    public float Speed()
    {
        return FlyWeightPointer.bulletSpeed;
    }

}
