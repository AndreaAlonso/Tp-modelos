using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Railgun : IGun
{
    private float _cd;
    private int _amount;

    public Railgun()
    {
        _cd = 0.7f;
        _amount = 30;
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
        var bullet = BulletPool.Instance.GetBullet();
        bullet.SetPosition(pos).SetType(new RayBullet());
        bullet.transform.forward = forward;

    }
}
