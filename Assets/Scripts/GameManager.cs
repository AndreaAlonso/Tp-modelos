using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IObserver {

    private int _enemiesCount;
    private int _wave;

    void Start () {

        FindObjectOfType<Player>().Subscribe(this);

      /*  var list = FindObjectsOfType<Enemy>();
        _enemiesCount = list.Length;
        for (int i = 0; i < list.Length; i++)
        {
            list[i].Subscribe(this);
        }
        */
	}
	
	void Update () {
		
	}

    public void Notify(bool enemy)
    {
        if (enemy)
            _enemiesCount--;
        else
            SceneManager.LoadScene("GameOver");
    }
}
