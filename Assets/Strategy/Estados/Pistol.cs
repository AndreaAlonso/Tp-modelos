using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : IGun {

    private float _cd;
    private int _amount;

    public Pistol()
    {
        _cd = 0.5f;
        _amount = 9999;

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
        bullet.SetPosition(pos).SetType(new NormalBullet());
        bullet.transform.forward = forward;

    }
}
