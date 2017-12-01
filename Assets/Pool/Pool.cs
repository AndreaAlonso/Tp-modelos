using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T>
{
    public List<PoolObject<T>> _poolList;
    public delegate T CallbackFactory();

    private int _count;
    private PoolObject<T>.PoolCallback _init;
    private PoolObject<T>.PoolCallback _finalize;
    private CallbackFactory _factoryMethod;

    public Pool(int initialCount, CallbackFactory factMetod, PoolObject<T>.PoolCallback initialization, PoolObject<T>.PoolCallback finalization)
    {
        _poolList = new List<PoolObject<T>>();

        _factoryMethod = factMetod;
        _count = initialCount;
        _init = initialization;
        _finalize = finalization;

        for (int i = 0; i < _count; i++)
        {
            _poolList.Add(new PoolObject<T>(_factoryMethod(), _init, _finalize));
        }
    }

    public T GetObjectFromPool()
    {
        for (int i = 0; i < _poolList.Count-1; i++)
        {
            if (!_poolList[i].isActive)
            {
                _poolList[i].isActive = true;
                //Debug.Log("Se supone que lo active");
                return _poolList[i].GetObj;
            }
        }
        PoolObject<T> po = new PoolObject<T>(_factoryMethod(),_init,_finalize);
        po.isActive = true;
        _poolList.Add(po);
        _count++;
        return po.GetObj;
    }

    public void DisablePoolObject(T obj)
    {
        foreach (PoolObject<T> O in _poolList)
        {
            if (O.GetObj.Equals(obj))
            {
                O.isActive = false;
                return;
            }
        }
    }
}
