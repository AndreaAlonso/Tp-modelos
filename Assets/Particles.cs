using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour {

    public Particles(Vector3 pos)
    {
        transform.position = pos;
    }
    virtual public void Initialize(){ }

    public void Dispose() { }

    public static void InitializeParticle(Particles bulletObj)
    {
        bulletObj.gameObject.SetActive(true);
        bulletObj.Initialize();
    }

    public static void DisposeParticle(Particles bulletObj)
    {
        bulletObj.Dispose();
        bulletObj.gameObject.SetActive(false);
    }
}
