﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {

    public int amount;
    public Bullet prefab;
    private Pool<Bullet> _bulletPool;

    private static BulletPool _instance;
    public static BulletPool Instance { get { return _instance; } }

    void Awake()
    {
        _instance = this;
        _bulletPool = new Pool<Bullet>(amount, BulletFactory, Bullet.InitializeBullet, Bullet.DisposeBullet);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _bulletPool.GetObjectFromPool();
        }
    }

    public Bullet GetBullet()
    {
        
        var bullet = _bulletPool.GetObjectFromPool();
        //bullet.gameObject.SetActive(true);
        //print(bullet.isActiveAndEnabled);
        bullet.Initialize();
        return bullet;
    }

    private Bullet BulletFactory()
    {
        return Instantiate<Bullet>(prefab);
    }
    public void ReturnBulletToPool(Bullet bullet)
    {
        _bulletPool.DisablePoolObject(bullet);
    }
}