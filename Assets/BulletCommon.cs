using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCommon : Bullet {

    private float _tick;

    public BulletCommon(Vector3 pos) : base(pos)
    {
        transform.position = pos;
    }
  
    void Start ()
    {
		
	}
	
	void Update ()
    {

        transform.position += transform.forward * FlyWeightPointer.bulletSpeed * Time.deltaTime;
        _tick += Time.deltaTime;
        if (_tick >= FlyWeightPointer.bulletLifeSpan)
        {
            BulletPool.Instance.ReturnBulletToPool(this);
        }

    }

    public override void Initialize()
    {
        _tick = 0;
        base.Initialize();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Enemy")
        {
            //c.GetComponent<Entity>().TakeDamage(_damage);
            print("hit");
            BulletPool.Instance.ReturnBulletToPool(this);
        }
        if (c.tag == "Walls")
        {
            BulletPool.Instance.ReturnBulletToPool(this);
        }

    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.tag == "Enemy")
        {
           // c.collider.GetComponent<Enemy>().TakeDamage(_damage);
            print("hit");
            BulletPool.Instance.ReturnBulletToPool(this);
        }
        if (c.collider.tag == "Walls")
        {
            BulletPool.Instance.ReturnBulletToPool(this);
        }
    }
}
