using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideController : IController {

    SuicideEnemy _model;
    ViewEnemy _view;
    Transform _hero;
    Transform _enemyTransform;
    float _distToShoot;

    public SuicideController(SuicideEnemy model, ViewEnemy view, Transform heroTransform, Transform enemyTransform)
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
