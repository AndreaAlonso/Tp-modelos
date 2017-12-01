using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRay : Bullet 
{

    public float speed;
    public float lifeSpan=2f;
    private float _tick;
    int _damage;
    

    public BulletRay(Vector3 pos) : base(pos)
    {
        transform.position = pos;
    }

    void Start ()
    {
        
    }
	

	void Update ()
    { 
        transform.position += transform.forward * speed * Time.deltaTime;

        _tick += Time.deltaTime;
        if (_tick >= lifeSpan)
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
        if (c.gameObject.GetComponent(typeof(Enemy)))
        {
            c.GetComponent<Entity>().TakeDamage(_damage);
        }
        if (c.tag == "Walls")
        {
            BulletPool.Instance.ReturnBulletToPool(this);
        }

    }
}
