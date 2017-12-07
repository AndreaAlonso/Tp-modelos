using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    IGun _myGun;

    public float Cooldown;
    public int Ammo;


	void Update ()
    {
        if (_myGun == null)
        {            
            _myGun = new Pistol();
            Cooldown = _myGun.CoolDown();
        }
    }

    public void Shoot()
    {
        if (_myGun == null)
            return;
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

    public void ChangeWeapon(IGun newWeapon)
    {
        _myGun = newWeapon;
        Ammo = _myGun.Reload();
        Cooldown = _myGun.CoolDown();
    }

    public float CD()
    {
        return Cooldown;
    }
}
