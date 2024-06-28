using System;
using System.Collections;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

public class ServiceLocator : SingletonMono<ServiceLocator>
{
    private readonly Hashtable _services = new Hashtable();

    private ServiceLocator()
    {
    }
        
    protected override void OnAwake()
    {
    }

    public void RegisterService<T>(T service)
    {
        Type type = typeof(T);
        if (!_services.ContainsKey(type))
        {
            _services.Add(type, service);
        }
        else
        {
            Debug.LogWarning("Service of type " + type + " is already registered.");
        }
    }
    public T GetService<T>() where T : MonoBehaviour
    {
        Type type = typeof(T);
        if (_services.ContainsKey(type))
        {
            return (T) _services[type];
        }

        var data = FindObjectOfType<T>(true);
        if (data == null)
        {
            Debug.LogWarning("Service of type " + type + " is not registered.");
            return default;
        }

        RegisterService(data);
        return data;
    }
}