using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int amount;
    public MeleeEnemy prefab;
    private Pool<MeleeEnemy> _enemyPool;

    private static Spawner _instance;
    public static Spawner Instance { get { return _instance; } }

    void Awake()
    {
        _instance = this;
        _enemyPool = new Pool<MeleeEnemy>(amount, EnemyFactory, MeleeEnemy.InitializeEnemy, MeleeEnemy.DisposeEnemy);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _enemyPool.GetObjectFromPool();
        }
    }

    private MeleeEnemy EnemyFactory()
    {
        return Instantiate(prefab);
    }
    public void ReturnEnemyToPool(MeleeEnemy enemy)
    {
        _enemyPool.DisablePoolObject(enemy);
    }
}
