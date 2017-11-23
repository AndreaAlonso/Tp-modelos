using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ModelPlayer {


    public event Action<int> OnDamage = delegate { };
    public event Action<int> OnShoot = delegate { };
    private Transform _playerTransform;
    public int hp;

    public ModelPlayer (Transform t)
    {
        _playerTransform = t;
    }

    public void OnMove(Vector3 newPos)
    {
        _playerTransform.position += newPos;
    }

    public void TakeDamage(int dmgRecieved)
    {
        hp -= dmgRecieved;
        OnDamage(hp);
    }

}
