using System;
using System.Collections.Generic;
using UnityEngine;

namespace ChainCraft.Data.Providers
{
    [CreateAssetMenu(menuName = "Scriptable Objects/ScriptableObjectsProvider")]
    public class ScriptableObjectsProviderConfig : ScriptableObject
    {
        public ScriptableObject[] scriptableObjects;
    }

    public class ScriptableObjectsProvider : IProvider<ScriptableObject>
    {
        private readonly Dictionary<Type, object> _objects;

        public ScriptableObjectsProvider(ScriptableObjectsProviderConfig config)
        {
            _objects = new Dictionary<Type, object>(config.scriptableObjects.Length);
            foreach (var @object in config.scriptableObjects)
            {
                _objects.Add(@object.GetType(), @object);
            }
        }

        public T Get<T>() where T : ScriptableObject
        {
            var config = _objects.GetValueOrDefault(typeof(T));
            return config as T;
        }
    }
}
