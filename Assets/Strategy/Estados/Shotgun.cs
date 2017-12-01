using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : IGun
{
    private float _cd;
    private int _amount;
    public Shotgun(float coolDown,int bullets)
    {
        _cd = coolDown;
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
