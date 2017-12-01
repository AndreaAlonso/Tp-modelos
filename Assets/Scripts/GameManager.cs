using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IObserver {

    private int _enemiesCount;
    private int _wave=1;
    private LookUpTable<int, int> enemiesAmount;
    private List<Enemy> enemiesOnScene = new List<Enemy>();

    void Start () {

        enemiesAmount = new LookUpTable<int, int>(Calculate);

        SpawnWave();

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

        if (_enemiesCount <= 0)
        {
            _wave++;
            SpawnWave();
        }
	}

    private void SpawnWave()
    {
        
    }

    public void Notify(bool enemy)
    {
        if (enemy)
            _enemiesCount--;
        else
            SceneManager.LoadScene("GameOver");
    }

    public int Calculate(int waveNumber)
    {
        return waveNumber * 5;
    }
}
