using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    private readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

    public static ServiceLocator Instance { get; private set; }

    public static void Initialize()
    {
        Instance = new ServiceLocator();
    }

    public T Get<T>() where T : IService
    {
        Type key = typeof(T);

        if (!_services.ContainsKey(key))
        {
            Debug.LogError($"{key} not registered with {GetType().Name}");
            throw new InvalidOperationException();
        }

        return (T)_services[key];
    }

    public void Register<T>(T service) where T : IService
    {
        Type key = typeof(T);

        if (_services.ContainsKey(key)) 
        {
            Debug.LogError($"Attempted to register service of type {key} " +
                $"which is already registered with the {GetType().Name}.");
            return;
        }

        _services.Add(key, service);
    }

    public void Unregister<T>() where T : IService
    {
        Type key = typeof(T);
        if (!_services.ContainsKey(key))
        {
            Debug.LogError($"Attempted to unregister service of " +
                $"type {key} which is not registered with the {GetType().Name}.");
            return;
        }

        _services.Remove(key);
    }
}
