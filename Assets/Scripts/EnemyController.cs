using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : IController {

    MeleeEnemy _model;
    ViewEnemy _view;
    Transform _hero;
    Transform _enemyTransform;

    public EnemyController(MeleeEnemy model, ViewEnemy view, Transform heroTransform, Transform enemyTransform)
    {
        _model = model;
        _view = view;
        _hero = heroTransform;
        _enemyTransform = enemyTransform;
    }

    public override void OnUpdate()
    {
        _model.OnMove((_hero.position - _enemyTransform.position).normalized);
    }

}
