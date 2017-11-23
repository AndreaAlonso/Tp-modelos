using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public ViewPlayer view;
    private Controller _controller;

	void Awake () {

        ModelPlayer model = new ModelPlayer(transform);
        _controller = new Controller(model, view);

	}
	
	// Update is called once per frame
	void Update () {
        _controller.OnUpdate();
	}
}
