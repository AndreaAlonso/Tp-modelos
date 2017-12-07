using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    IGun _myGun;

    public float Cooldown;
    public int Ammo;


    public bool pistol;
    public bool railgun;
    public bool shotgun;

    void Start ()
    {
        
    }

	void Update ()
    {
        if (_myGun == null)
        {
            if (pistol)
                _myGun = new Pistol();
            else if(railgun)
                _myGun = new Railgun();
            else
                _myGun = new Shotgun();
            Cooldown = _myGun.CoolDown();
        }
    }

    public void Shoot()
    {
        if (Ammo > 0)
        {
            _myGun.Shoot(transform.position,transform.forward);
            Ammo--;
        }
        else
        {
            _myGun = new Pistol();
            Ammo = _myGun.Reload();
        }
    }

    void ChangeWeapon(IGun newWeapon)
    {
        _myGun = newWeapon;
        Ammo = _myGun.Reload();
    }
}
