using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Railgun : IGun
{
    private float _cd;
    private int _amount;
    public Railgun(float cooldown, int bullets)
    {
        _cd = cooldown;
        _amount = bullets;
    }
        
    public float CoolDown()
    {
        return _cd;
    }

    public int Reload()
    {
        return _amount;
    }

    public void Shoot()
    {
        
    }

}
