using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpTable<T1,T2>
{
    public delegate T2 FactoryMethod(T1 key);
}
