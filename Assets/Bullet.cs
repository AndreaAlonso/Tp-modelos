using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public float lifeSpan;
    private float _tick;
    Vector3 posSpawner;
    

    public Bullet(Vector3 pos)
    {
        posSpawner = pos;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        _tick += Time.deltaTime;
        if (_tick >= lifeSpan)
        {
            Weapon.Instance.ReturnBulletToPool(this);
        }
    }
    void OnTriggerEnter(Collider c)
    {
        if (c is MeleeEnemy)
        {
            Weapon.Instance.ReturnBulletToPool(this);
        }
        if (c.tag == "Walls")
        {
            Weapon.Instance.ReturnBulletToPool(this);
        }

    }
    public void Initialize()
    {
        
        _tick = 0;
        transform.position = posSpawner;
    }

    public void Dispose() { }

    public static void InitializeBullet(Bullet bulletObj)
    {
        bulletObj.gameObject.SetActive(true);
        bulletObj.Initialize();
    }

    public static void DisposeBullet(Bullet bulletObj)
    {
        bulletObj.Dispose();
        bulletObj.gameObject.SetActive(false);
    }
}
