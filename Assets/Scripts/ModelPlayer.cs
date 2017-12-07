using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ModelPlayer : Entity, IObservable {


    public ViewPlayer view;

    public event Action<int> OnDamage = delegate { };
    private bool _canShoot=true;
    public Weapon weapon;

    private float _speed;
    private bool _gettingPushed;
    private Vector3 _pushDirection;


    private void Awake()
    {
        _speed = 6f;
        hp = 500;
        view = new ViewPlayer();
        controller = new PlayerController(this, view);
        weapon = GetComponentInChildren<Weapon>();

    }
    
    private void Update()
    {
        if (_gettingPushed)
            OnMove(_pushDirection);
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

    public override void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp >= 0)
            OnDamage(hp);       
        else        
            manager.Notify(false);

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
        if (c.GetComponent(typeof(Bullet)))
        {
            TakeDamage(((Bullet)c.GetComponent(typeof(Bullet))).currentBullet.DamageDone());
        }
        else if (c.GetComponent(typeof(IPickable)))
        {
            weapon.ChangeWeapon(c.GetComponent<IPickable>().Effect());
        }
    }

  /*  private void OnCollisionEnter(Collision c)
    {
        if(c.collider.GetComponent(typeof(Enemy)))
        {
            TakeDamage(((Enemy)c.collider.GetComponent(typeof(Enemy))).dmg);
            _pushDirection = (transform.position - c.collider.transform.position).normalized*3f;
            _gettingPushed = true;
            StartCoroutine(NormalMove());
        }
    }*/

    public void PushAndDamage(int dmg, Vector3 dir)
    {
        _pushDirection = dir.normalized * 3f;
        _gettingPushed = true;
        StartCoroutine(NormalMove());
    }

    private IEnumerator NormalMove()
    {
        yield return new WaitForSeconds(0.5f);
        _gettingPushed = false;
    }


}
