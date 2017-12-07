using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : IGun
{
    private float _cd;
    private int _amount;

    public Shotgun()
    {
        _cd = 1f;
        _amount = 36;
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
        
        for (int i = -1; i < 2; i++)
        {
            var bullet = BulletPool.Instance.GetBullet();
            bullet.SetPosition(pos).SetType(new NormalBullet());
            bullet.transform.forward = forward;
            bullet.transform.forward += bullet.transform.right * i * 0.5f;

        }

    }
}
