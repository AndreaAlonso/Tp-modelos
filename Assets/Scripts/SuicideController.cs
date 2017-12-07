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
        if (Vector3.Distance(_hero.position, _enemyTransform.position) >= 3f)
            _model.OnMove((_hero.position - _enemyTransform.position).normalized);
        else
            _model.Attack();
    }
}
