using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity  {

    public int dmg=10;

    public static void InitializeEnemy(Enemy enemyObj)
    {
        enemyObj.gameObject.SetActive(true);
        enemyObj.Initialize();
    }

    public void Initialize()
    {
        hp = FlyWeightPointer.State.hpMax;
    }

    public static void DisposeEnemy(Enemy enemyObj)
    {
        enemyObj.Dispose();
        enemyObj.gameObject.SetActive(false);
    }

    public Enemy SetPos(Vector3 newPos)
    {
        transform.position = newPos;
        return this;
    }

    public void Dispose()
    {

    }

    public override void OnMove(Vector3 dir)
    {
        
    }

    public override void TakeDamage(int dmg)
    {
        
    }

    public override void Attack()
    {
        
    }

    public virtual void Subscribe(IObserver obs)
    {
        manager = obs;
    }
}
