using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int amount;
    public List <Enemy> prefab;
    private Pool<Enemy> _enemyPool;

    private static Spawner _instance;
    public static Spawner Instance { get { return _instance; } }

    void Awake()
    {
        _instance = this;
        _enemyPool = new Pool<Enemy>(amount, EnemyFactory, Enemy.InitializeEnemy, Enemy.DisposeEnemy);
    }

    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            _enemyPool.GetObjectFromPool();
        }*/
    }

    public Enemy SpawnEnemy()
    {
        return _enemyPool.GetObjectFromPool();
    }

    private Enemy EnemyFactory()
    {
        return Instantiate<Enemy>(prefab[Random.Range(0, prefab.Count)]);
    }
    public void ReturnEnemyToPool(Enemy enemy )
    {
        _enemyPool.DisablePoolObject(enemy);
    }
}
