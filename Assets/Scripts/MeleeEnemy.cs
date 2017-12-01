using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy {

    public ViewEnemy view;
    public event Action<int> OnDamage = delegate { };

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
        controller.OnUpdate();
	}

    public override void OnMove(Vector3 newPos)
    {
        if (newPos != Vector3.zero)
            transform.forward = newPos;
        transform.position += newPos * Time.deltaTime * FlyWeightPointer.State.speed;
    }

    public override void TakeDamage(int dmg)
    {
        hp -= dmg;
        OnDamage(hp);
    }

    public override void Attack()
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent(typeof(Bullet)))
        {
            TakeDamage(other.GetComponent<Bullet>().dmg);
        }
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
