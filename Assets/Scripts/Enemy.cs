using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IObservable {

    public ViewEnemy view;
    private IController _IA;
    private IObserver _manager;
   

    void Awake()
    {
        ModelEnemy _model = new ModelEnemy(transform, FlyWeightPointer.State.hpMax, FlyWeightPointer.State.speed);
        //_model.LifeBar += view.ReceivedDamage;
        view = new ViewEnemy();
        //_IA = new EnemyController(_model, view, FindObjectOfType<ModelPlayer>().transform, transform);
    }

    public virtual void Update()
    {
        _IA.OnUpdate();
    }

    public void Subscribe(IObserver obs)
    {
        _manager = obs;
    }

    private void OnDeath()
    {
        _manager.Notify(true);
    }
}
