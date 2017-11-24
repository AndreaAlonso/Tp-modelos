﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : IController {

    ModelEnemy _model;
    ViewEnemy _view;
    Transform _hero;
    Transform _enemyTransform;

    public EnemyController(ModelEnemy model, ViewEnemy view, Transform heroTransform, Transform enemyTransform)
    {
        _model = model;
        _view = view;
        _hero = heroTransform;
        _enemyTransform = enemyTransform;
    }

    public override void OnUpdate()
    {
        _model.Move(_hero.position - _enemyTransform.position);
    }

}