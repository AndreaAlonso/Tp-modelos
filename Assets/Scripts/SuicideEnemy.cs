using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SuicideEnemy : Enemy {

    public ViewEnemy view;
    public event Action<int> OnDamage = delegate { };
    private bool _exploding;
    public bool stopped;


    private void Awake()
    {
        hp = FlyWeightPointer.SuicideEnemy.hpMax;
        view = new ViewEnemy();
        controller = new SuicideController(this, view, FindObjectOfType<ModelPlayer>().transform, transform);
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
            transform.forward = newPos;
        transform.position += newPos * Time.deltaTime * FlyWeightPointer.SuicideEnemy.speed;
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
            Destroy(this.gameObject);
    }

    private IEnumerator MoveAgain()
    {
        yield return new WaitForSeconds(0.5f);
        stopped = false;
    }

    public override void Attack()
    {
        _exploding = true;
        stopped=true;
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        manager.Notify(true);
        Spawner.Instance.ReturnEnemyToPool(this);
        
    }

    public override void Subscribe(IObserver obs)
    {
        base.Subscribe(obs);
    }

    private void OnTriggerStay(Collider c)
    {
        if (_exploding && c.GetComponent(typeof(ModelPlayer)))
        {
            c.GetComponent<ModelPlayer>().TakeDamage(FlyWeightPointer.explosionDamage);
            _exploding = false;
        }
    }
    /*
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

    }*/
}
