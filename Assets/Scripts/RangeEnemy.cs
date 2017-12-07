using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RangeEnemy : Enemy {

    public ViewEnemy view;
    public event Action<int> OnDamage = delegate { };
    Weapon weapon;
    private bool _reloading;
    private bool _stop;
    bool stopped;

    private void Awake()
    {
        hp = FlyWeightPointer.RangeEnemy.hpMax;
        view = new ViewEnemy();
        controller = new RangeController(this, view, FindObjectOfType<ModelPlayer>().transform, transform);
        weapon = GetComponentInChildren<Weapon>();
    }


    public void Update()
    {
        if (stopped)
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
        transform.position += newPos * Time.deltaTime * FlyWeightPointer.RangeEnemy.speed;
    }

    public override void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp >= 0)
        {
            OnDamage(hp);
            stopped = true;
            StartCoroutine(MoveAgain());
        }
        else
        {
            manager.Notify(true);
            Spawner.Instance.ReturnEnemyToPool(this);
        }
    }

    private IEnumerator MoveAgain()
    {
        yield return new WaitForSeconds(0.5f);
        stopped = false;
    }

    public override void Attack()
    {
        weapon.Shoot();
        print("Pew pew");
        _reloading = true;
        StartCoroutine(Reload());
    }

    public void Aim(Vector3 dir)
    {
        transform.forward = dir;
    }

    public bool IsReloading()
    {
        return _reloading;
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(weapon.Cooldown+FlyWeightPointer.aimTime);
        _reloading = false;
    }

  /*  public static void InitializeEnemy(MeleeEnemy enemyObj)
    {
        enemyObj.gameObject.SetActive(true);
        enemyObj.Initialize();
    }

    public void Initialize()
    {
        hp = FlyWeightPointer.RangeEnemy.hpMax;
    }

    public static void DisposeEnemy(MeleeEnemy enemyObj)
    {
        enemyObj.Dispose();
        enemyObj.gameObject.SetActive(false);
    }

    public void Dispose()
    {

    }*/
}
