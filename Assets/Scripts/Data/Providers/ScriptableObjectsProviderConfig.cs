using UnityEngine;

namespace ChainCraft.Data.Providers
{
    [CreateAssetMenu(menuName = "Scriptable Objects/ScriptableObjectsProvider")]
    public class ScriptableObjectsProviderConfig : ScriptableObject
    {
        public ScriptableObject[] scriptableObjects;
    }
}
