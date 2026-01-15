using ChainCraft.Core.Gameplay;
using UnityEngine;

namespace ChainCraft.Data
{
    [CreateAssetMenu(menuName = "Scriptable Objects/PrefabsConfig")]
    public class PrefabsConfig : ScriptableObject
    {
        public ProducerUI producerUIPrefab => _producerUIPrefab;

        [SerializeField] private ProducerUI _producerUIPrefab;
    }
}