using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyWeightPointer
{
    public static readonly FlyWeight State = new FlyWeight()
    {
        hpMax = 100,
        speed = 3
    };

    public static readonly FlyWeight SuicideEnemy = new FlyWeight()
    {
        hpMax = 50,
        speed = 7
    };

    public static readonly FlyWeight RangeEnemy = new FlyWeight()
    {
        hpMax = 150,
        speed = 4
    };

    public static readonly float bulletSpeed = 30f;
    public static readonly float raySpeed = 50f;

    public static readonly float distToShoot = 10f;

    public static readonly float bulletLifeSpan = 10f;
    public static readonly float rayLifeSpan = 2f;

    public static readonly int bulletDamage = 25;
    public static readonly int rayDamage=15;
}
