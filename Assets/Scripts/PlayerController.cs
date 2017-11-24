using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : IController {

    ModelPlayer _model;
    ViewPlayer _view;

    public PlayerController(ModelPlayer model, ViewPlayer view)
    {
        _model = model;
        _view = view;
        _view.RepaintLife(_model.hp);
        _model.OnDamage += _view.RepaintLife;
    }

    public override void OnUpdate()
    {
        _model.OnMove(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }
}
