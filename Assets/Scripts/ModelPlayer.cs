using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ModelPlayer : Entity, IObservable {


    public ViewPlayer view;
    private IController _controller;

    public event Action<int> OnDamage = delegate { };
    public event Action<int> OnShoot = delegate { };
    //private Transform _playerTransform;
    //public int hp;
   // private float _speed;
    private bool _canShoot;
    public IGun weapon;
    //private IObserver _manager;

    private void Awake()
    {
        hp = FlyWeightPointer.State.hpMax;
        speed = FlyWeightPointer.State.speed;
        view = new ViewPlayer();
        _controller = new PlayerController(this, view);
    }


    private void Update()
    {
        _controller.OnUpdate();
    }

  /*  public ModelPlayer (Transform t, int maxHp, float speed)
    {
        _playerTransform = t;
        hp = maxHp;
        _speed = speed;
    }
    */

    public override void OnMove(Vector3 newPos)
    {
        if(newPos!=Vector3.zero)
            transform.forward = newPos;
        transform.position += newPos*Time.deltaTime*speed;
    }

    public override void TakeDamage(int dmgReceived)
    {
        hp -= dmgReceived;
        OnDamage(hp);
    }

    public override void Attack()
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

    public void Subscribe(IObserver obs)
    {
        manager = obs;
    }

    private void OnTriggerEnter(Collider c)
    {
        if(c is IPickable)
        {
            c.GetComponent<IPickable>().Effect();
            return;
        }
        if(c is IDebuff)
        {
            c.GetComponent<IDebuff>().Debuff();
        }
    }
}
