using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int dmg;

    public Bullet(Vector3 pos)
    {
        transform.position = pos;
    }
    void Update()
    {
    }
    void OnTriggerEnter(Collider c)
    {
        if (c == FindObjectOfType<Enemy>())
        {
            BulletPool.Instance.ReturnBulletToPool(this);
        }
        if (c.tag == "Walls")
        {
            BulletPool.Instance.ReturnBulletToPool(this);
        }

    }
    virtual public void Initialize()
    {
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
