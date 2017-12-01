using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    float CoolDown();
    void Shoot();

    int Reload();
	
}
