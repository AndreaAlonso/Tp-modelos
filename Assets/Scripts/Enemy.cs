using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public ViewEnemy view;
    private IController _IA;

    void Awake()
    {
        ModelEnemy _model = new ModelEnemy(transform, FlyWeightPointer.State.hpMax, FlyWeightPointer.State.speed);
        _IA = new EnemyController(_model, view, FindObjectOfType<Player>().transform, transform);
    }

    void Update()
    {
        _IA.OnUpdate();
    }
}
