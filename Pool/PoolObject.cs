using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject<T>
{
    private bool _isActive;
    private T _obj;
    public delegate void PoolCallback(T obj);
    private PoolCallback _iniCallback;
    private PoolCallback _finCallback;

    public PoolObject(T obj, PoolCallback initialization, PoolCallback finalization)
    {
        _obj = obj;
        _iniCallback = initialization;
        _finCallback = finalization;
        _isActive = false;
    }

    public T GetObj
    {
        get
        {
            return _obj;
        }
    }

    public bool isActive
    {
        get
        {
            return _isActive;
        }
        set
        {
            _isActive = value;
            if (_isActive)
            {
                if (_iniCallback != null)
                    _iniCallback(_obj);
            }
            else
            {
                if (_finCallback != null)
                    _finCallback(_obj);
            }
        }
    }
}
