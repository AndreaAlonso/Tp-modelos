using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MeleeController : IController {

    MeleeEnemy _model;
    ViewEnemy _view;
    Transform _hero;
    Transform _enemyTransform;
    LayerMask obstacles;
    LayerMask friends;
    List<Collider> avoid=new List<Collider>();
    Collider closerOb;
    float avoidWeight=10;

    public MeleeController(MeleeEnemy model, ViewEnemy view, Transform heroTransform, Transform enemyTransform)
    {
        _model = model;
        _view = view;
        _hero = heroTransform;
        _enemyTransform = enemyTransform;
        obstacles = LayerMask.NameToLayer("Obstacles");
        friends = LayerMask.NameToLayer("Enemies");
    }

    public override void OnUpdate()
    {
        GetObstaclesToAvoid();
        _model.OnMove((_hero.position - _enemyTransform.position+Avoid()*avoidWeight).normalized);
    }

    private void GetObstaclesToAvoid()
    {
        /*avoid.Clear();
        avoid.AddRange(Physics.OverlapSphere(_enemyTransform.position, 5f, obstacles));
        if (avoid.Count > 0)
        {
            Debug.Log(avoid.Count);
            closerOb = avoid.OrderBy(x => Vector3.Distance(x.transform.position, _enemyTransform.position)).First();
        }*/
    }

    public Vector3 Avoid()
    {
        if (closerOb)
            return _enemyTransform.position - closerOb.transform.position;
        else return Vector3.zero;
    }
}
