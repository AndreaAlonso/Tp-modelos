using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public IBullet currentBullet;
    private float _tick;

    void Update()
    {   
            transform.position += transform.forward * currentBullet.Speed() * Time.deltaTime;
            _tick += Time.deltaTime;
            if (_tick >= currentBullet.LifeSpan())
            {
                BulletPool.Instance.ReturnBulletToPool(this);
            }        
    }

     void OnTriggerEnter(Collider c)
    {
        currentBullet.OnHit(c);
        if(currentBullet.NeedToDestroy())
            BulletPool.Instance.ReturnBulletToPool(this);

    }

    public Bullet SetPosition(Vector3 newPos)
    {
        transform.position = newPos;
        return this;
    }

    public Bullet SetType(IBullet newType)
    {
        currentBullet = newType;
        return this;
    }

    public void Initialize()
    {
        _tick = 0;
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
