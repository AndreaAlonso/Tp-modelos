using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickShotgun : MonoBehaviour, IPickable {

    public IGun Effect()
    {
        return new Shotgun();
    }

    public void OnPick()
    {
        PickManager.Instance.DeactivatePick(gameObject);
    }

    public void OnTriggerEnter(Collider c)
    {
        if(c.GetComponent(typeof(ModelPlayer)))
            PickManager.Instance.DeactivatePick(gameObject);
    }
}
