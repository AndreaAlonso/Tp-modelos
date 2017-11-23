using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyWeightPointer
{
    public static readonly FlyWeight State = new FlyWeight()
    {
        hpMax = 100,
        speed = 5
    };

}
