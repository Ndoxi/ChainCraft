using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChainCraft.Infrastracture
{
    public static class ServiceLocator
    {
        static readonly Dictionary<Type, object> services = new();

        public static T Resolve<T>() where T : class
        {
            var type = typeof(T);
            if (services.TryGetValue(type, out var service))
                return service as T;

            throw new InvalidOperationException($"Service of type {type.FullName} is not registered.");
        }

        public static void Register<T>(T service) where T : class
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));

            var type = typeof(T);
            if (services.ContainsKey(type))
            {
                Debug.LogWarning($"Service of type {type.FullName} is already registered. Replacing existing instance.");
                services[type] = service;
            }
            else
            {
                services.Add(type, service);
            }
        }

        public static void Unregister<T>(bool dispose = true) where T : class
        {
            var type = typeof(T);
            if (services.TryGetValue(type, out object service))
            {
                if (dispose && service is IDisposable disposable)
                    disposable.Dispose();
                services.Remove(type);
            }
            else
            {
                Debug.LogWarning($"Attempted to unregister service of type {type.FullName} but it was not registered.");
            }
        }
    }
}
