using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ModelPlayer : Entity, IObservable {


    public ViewPlayer view;

    public event Action<int> OnDamage = delegate { };
    public event Action<int> OnShoot = delegate { };
    private bool _canShoot=true;
    public Weapon weapon;


    public bool pistol;
    public bool railgun;
    public bool shotgun;

    private float _speed;


    private void Awake()
    {
        _speed = 5f;
        hp = FlyWeightPointer.State.hpMax;
        view = new ViewPlayer();
        controller = new PlayerController(this, view);
        weapon = GetComponentInChildren<Weapon>();
        weapon.pistol = pistol;
        weapon.railgun = railgun;
        weapon.shotgun = shotgun;
    }


    private void Update()
    {
        if (controller == null)
            return;
        controller.OnUpdate();
    }

    public override void OnMove(Vector3 newPos)
    {
        if (newPos != Vector3.zero)
        {
            newPos.y = 0;
            transform.forward = newPos;
        }
        transform.position += newPos*Time.deltaTime* _speed;
    }

    public override void TakeDamage(int dmgReceived)
    {
        hp -= dmgReceived;
        OnDamage(hp);
    }

    public override void Attack()
    {
        if (_canShoot)
        {
            weapon.Shoot();
            _canShoot = false;
            StartCoroutine(WaitToShoot(weapon.Cooldown));

        }
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
