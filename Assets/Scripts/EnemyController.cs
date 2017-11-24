using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : IController {

    ModelEnemy _model;
    ViewEnemy _view;
    Transform _hero;

    public EnemyController(ModelEnemy model, ViewEnemy view, Transform heroTransform)
    {
        _model = model;
        _view = view;
        _hero = heroTransform;
    }

    public override void OnUpdate()
    {
        
    }

}
