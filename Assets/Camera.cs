using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    Transform player;

	void Awake () {
        player = FindObjectOfType<ModelPlayer>().transform;
	}
	
	
	void Update () {
        Vector3 newPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.position = newPos;
        
	}
}
