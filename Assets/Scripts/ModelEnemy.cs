using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ModelEnemy : MonoBehaviour  {

    public event Action<int> LifeBar = delegate { };
    private Transform _enemyTransform;
    public int _hp;
    private float _speed;

    public ModelEnemy (Transform t, int maxHp, float speed)
    {
        _enemyTransform = t;
        _hp = maxHp;
        _speed = speed;
    }

    public void OnDamage(int dmgReceived)
    {
        _hp -= dmgReceived;
    }

    public void Move(Vector3 dir)
    {
        _enemyTransform.position += dir * Time.deltaTime * _speed;
    }
}
