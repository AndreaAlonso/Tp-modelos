using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SuicideEnemy : Entity {

    public ViewEnemy view;
    public event Action<int> OnDamage = delegate { };
    private bool _exploding_;

    private void Awake()
    {
        hp = FlyWeightPointer.RangeEnemy.hpMax;
        view = new ViewEnemy();
        controller = new SuicideController(this, view, FindObjectOfType<ModelPlayer>().transform, transform);
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
        _exploding_ = true;
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        //DisposeEnemy(this);
    }

    public static void InitializeEnemy(MeleeEnemy enemyObj)
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

    }
}
