using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IObservable {

    public ViewPlayer view;
    private IController _controller;
    private IObserver _manager;

    void Awake () {

        //ModelPlayer model = new ModelPlayer(transform, FlyWeightPointer.State.hpMax,FlyWeightPointer.State.speed);
        //_controller = new PlayerController(model, view);

	}

	void Update () {
        _controller.OnUpdate();
	}

    public void Subscribe(IObserver obs)
    {
        _manager = obs;
    }

    private void OnDestroy()
    {
        _manager.Notify(false);
    }
}
