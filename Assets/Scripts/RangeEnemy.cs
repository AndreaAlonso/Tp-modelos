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

    private void Awake()
    {
        hp = FlyWeightPointer.RangeEnemy.hpMax;
        view = new ViewEnemy();
        controller = new RangeController(this, view, FindObjectOfType<ModelPlayer>().transform, transform);
        weapon = GetComponentInChildren<Weapon>();
    }


    public void Update()
    {
        controller.OnUpdate();
    }

    public override void OnMove(Vector3 newPos)
    {
        if (newPos != Vector3.zero)
            transform.forward = newPos;
        transform.position += newPos * Time.deltaTime * FlyWeightPointer.RangeEnemy.speed;
    }

    public override void TakeDamage(int dmg)
    {
        hp -= dmg;
        OnDamage(hp);
    }

    public override void Attack()
    {
        weapon.Shoot();
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
        yield return new WaitForSeconds(weapon.Cooldown);
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
