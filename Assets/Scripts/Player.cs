using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public ViewPlayer view;
    public int maxHp;
    private PlayerController _controller;

	void Awake () {

        ModelPlayer model = new ModelPlayer(transform, maxHp);
        _controller = new PlayerController(model, view);

	}
	
	// Update is called once per frame
	void Update () {
        _controller.OnUpdate();
	}
}
