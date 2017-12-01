﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : IGun {

    private float _cd;
    private int _amount;
    private BulletPool _pool;

    public Pistol(float cooldown, int bullets, BulletPool pool)
    {
        _cd = cooldown;
        _amount = bullets;
        _pool = pool;
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
        Debug.Log("sadsadsa");
        bullet.transform.position = pos;
        bullet.transform.forward = forward;

    }
}
