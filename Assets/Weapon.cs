using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    IGun _myGun;
    

    public float Cooldown;
    public int Ammo;

    void Start ()
    {
        
    }

	void Update ()
    {
        if (_myGun == null)
            _myGun = new Pistol(Cooldown, Ammo, FindObjectOfType<BulletPool>());
        
    }

    public void Shoot()
    {
        _myGun.Shoot(transform.position,transform.forward);
    }

    void ChangeWeapon(IGun newWeapon)
    {
        _myGun = newWeapon;
    }
}
