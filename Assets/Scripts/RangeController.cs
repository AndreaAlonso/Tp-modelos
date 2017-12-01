using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeController : IController {

    RangeEnemy _model;
    ViewEnemy _view;
    Transform _hero;
    Transform _enemyTransform;

    public RangeController(RangeEnemy model, ViewEnemy view, Transform heroTransform, Transform enemyTransform)
    {
        _model = model;
        _view = view;
        _hero = heroTransform;
        _enemyTransform = enemyTransform;
    }

    public override void OnUpdate()
    {
        if (Vector3.Distance(_enemyTransform.position, _hero.position) < FlyWeightPointer.distToShoot)
            if (!_model.IsReloading())
                _model.Attack();
            else
                _model.Aim((_hero.position - _enemyTransform.position).normalized);

        else
            _model.OnMove((_hero.position - _enemyTransform.position).normalized);
    }
}
