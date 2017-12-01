using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    float CoolDown();
    void Shoot(Vector3 posSpawn, Vector3 forward);

    int Reload();
	
}
