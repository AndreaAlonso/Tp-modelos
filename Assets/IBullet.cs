using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet {

    void OnHit(Collider c);
    int DamageDone();
    float LifeSpan();
    float Speed();
    bool NeedToDestroy();
}
