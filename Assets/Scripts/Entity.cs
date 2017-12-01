using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {

    public IController controller;
    public int hp;
    public IObserver manager;

    public abstract void OnMove(Vector3 dir);
    public abstract void TakeDamage(int dmg);
    public abstract void Attack();

}
