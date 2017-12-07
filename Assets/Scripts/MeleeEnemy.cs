using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy {

    public ViewEnemy view;
    public event Action<int> OnDamage = delegate { };
    public bool stopped;

    private void Awake()
    {
        hp = FlyWeightPointer.State.hpMax;
        view = new ViewEnemy();
        controller = new MeleeController(this, view, FindObjectOfType<ModelPlayer>().transform, transform);
    }

	public void Update ()
    {
        if (controller == null)
            return;
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
        transform.position += newPos * Time.deltaTime * FlyWeightPointer.State.speed;
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

    public override void Attack()
    {
        stopped = true;
        StartCoroutine(MoveAgain());
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.GetComponent(typeof(Bullet)))
        {
            TakeDamage(((Bullet)c.GetComponent(typeof(Bullet))).currentBullet.DamageDone());            
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.GetComponent(typeof(ModelPlayer)))
        {
            c.collider.GetComponent<ModelPlayer>().PushAndDamage(dmg, c.collider.transform.position - transform.position);
            Attack();        
        }
    }

    private IEnumerator MoveAgain()
    {
        yield return new WaitForSeconds(0.5f);
        stopped = false;
    }

    //public static void InitializeEnemy(MeleeEnemy enemyObj)
    //{
    //    enemyObj.gameObject.SetActive(true);
    //    enemyObj.Initialize();
    //}

    //public void Initialize()
    //{
    //    hp = FlyWeightPointer.State.hpMax;
    //}

    //public static void DisposeEnemy(MeleeEnemy enemyObj)
    //{
    //    enemyObj.Dispose();
    //    enemyObj.gameObject.SetActive(false);
    //}

    //public void Dispose()
    //{

    //}
}
