using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Railgun : IGun
{
    private float _cd;
    private int _amount;
    private BulletPool _pool;

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

    public void Shoot(Vector3 pos, Vector3 forward)
    {
        var bullet = _pool.GetBullet();
        bullet.transform.position = pos;
        bullet.transform.forward = forward;

    }
}
