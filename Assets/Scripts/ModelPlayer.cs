using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ModelPlayer {


    public event Action<int> OnDamage = delegate { };
    public event Action<int> OnShoot = delegate { };
    private Transform _playerTransform;
    public int hp;
    private int _speed;

    public ModelPlayer (Transform t, int maxHp, int speed)
    {
        _playerTransform = t;
        hp = maxHp;
        _speed = speed;
    }

    public void OnMove(Vector3 newPos)
    {
        _playerTransform.position += newPos*Time.deltaTime*_speed;
    }

    public void TakeDamage(int dmgReceived)
    {
        hp -= dmgReceived;
        OnDamage(hp);
    }

}
