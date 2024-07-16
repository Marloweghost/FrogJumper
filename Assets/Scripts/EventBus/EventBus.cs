using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : IService
{
    private Dictionary<string, List<object>> signalCallbacks = new Dictionary<string, List<object>>();

    public void Subscribe<T>(Action<T> _callback)
    {
        string _key = typeof(T).Name;

        if (signalCallbacks.ContainsKey(_key))
        {
            signalCallbacks[_key].Add(_callback);
        }
        else
        {
            signalCallbacks.Add(_key, new List<object>() { _callback });
        }
    }

    public void Unsubscribe<T>(Action<T> _callback)
    {
        string _key = typeof(T).Name;

        if (signalCallbacks.ContainsKey(_key))
        {
            signalCallbacks[_key].Remove(_callback);
        }
        else
        {
            Debug.LogErrorFormat("Trying to unsubscribe from non existing key!", _key);
        }
    }

    public void Invoke<T>(T _signal)
    {
        string _key = typeof(T).Name;

        if (signalCallbacks.ContainsKey(_key))
        {
            foreach (var _obj in signalCallbacks[_key])
            {
                var _callback = _obj as Action<T>;
                _callback.Invoke(_signal);
            }
        }
    }
}
