using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Entity {

    public ViewEnemy view;
    public event Action<int> OnDamage = delegate { };

    private void Awake()
    {
        hp = FlyWeightPointer.State.hpMax;
        speed = FlyWeightPointer.State.speed;
        view = new ViewEnemy();
        controller = new EnemyController(this, view, FindObjectOfType<ModelPlayer>().transform, transform);
    }

    void Start () {
		
	}

	public void Update () {

        controller.OnUpdate();
	}

    public override void OnMove(Vector3 newPos)
    {
        if (newPos != Vector3.zero)
            transform.forward = newPos;
        transform.position += newPos * Time.deltaTime * speed;
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

    public static void InitializeEnemy(MeleeEnemy enemyObj)
    {
        enemyObj.gameObject.SetActive(true);
        enemyObj.Initialize();
    }

    private void Initialize()
    {
        
    }

    public static void DisposeEnemy(MeleeEnemy enemyObj)
    {
        enemyObj.Dispose();
        enemyObj.gameObject.SetActive(false);
    }

    private void Dispose()
    {
        
    }
}
