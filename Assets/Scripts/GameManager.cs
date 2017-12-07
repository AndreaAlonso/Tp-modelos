using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IObserver {

    public int _enemiesCount;
    private int _wave=1;
    private LookUpTable<int, int> enemiesAmount;
    private List<Enemy> enemiesOnScene = new List<Enemy>();
    public List<Transform> spawns=new List<Transform>();
    private ModelPlayer _hero;

    void Start () {

        enemiesAmount = new LookUpTable<int, int>(Calculate);

        StartCoroutine(SpawnWave());

        _hero = FindObjectOfType<ModelPlayer>();
        _hero.Subscribe(this);

	}
	
	void Update () {

        //if (_enemiesCount <= 0)
        //{
        //    _wave++;
        //    SpawnWave();
        //}
	}


    private IEnumerator SpawnWave()
    {
        var cant = enemiesAmount.ReturnValue(_wave);
        for (int i = 0; i < cant; i++)
        {
            for (int j = 0; j < spawns.Count; j++)
            {
               Spawner.Instance.SpawnEnemy().SetPos(spawns[j].position).Subscribe(this);
                _enemiesCount++;
                i++;
                if (i > cant)
                    break;
                yield return new WaitForSeconds(0.1f);
                
            }
        }
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
