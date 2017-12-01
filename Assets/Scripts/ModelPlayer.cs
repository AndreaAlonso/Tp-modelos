using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ModelPlayer : MonoBehaviour {

    public event Action<int> OnDamage = delegate { };
    public event Action<int> OnShoot = delegate { };
    private Transform _playerTransform;
    public int hp;
    private float _speed;
    private bool _canShoot;
    public IGun weapon;

    public ModelPlayer (Transform t, int maxHp, float speed)
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

    public void Shoot()
    {
        weapon.Shoot();
        _canShoot = false;
        StartCoroutine(WaitToShoot(weapon.CoolDown()));
    }

    public IEnumerator WaitToShoot (float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        _canShoot = true;
    }

    
}
