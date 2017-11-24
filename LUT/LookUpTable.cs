using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpTable<T1, T2>
{
    // Falta asignar valores de cantidad de enemigos

    public delegate T2 Factorymethod(T1 keyToReturn);

    Dictionary<T1, T2> _table = new Dictionary<T1, T2>();

    Factorymethod factoryMethod;

    public LookUpTable(Factorymethod newFactory)
    {
        factoryMethod = newFactory;
    }
    public T2 ReturnValue (T1 myKey)
    {
        if (_table.ContainsKey(myKey))
        {

           return _table[myKey];
        }
        else
        {
            var value = factoryMethod(myKey);
            _table[myKey] = value;
            return value;
        }

    }

}