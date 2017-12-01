using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Entity {

    public ViewEnemy view;
    public event Action<int> OnDamage = delegate { };

    private void Awake()
    {
        controller = new EnemyController(this, view, FindObjectOfType<ModelPlayer>().transform, transform);
    }

    void Start () {
		
	}

	public void Update () {

        

	}

    public override void OnMove(Vector3 dir)
    {
        
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
}
