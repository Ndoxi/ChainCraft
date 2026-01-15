using UnityEngine;

namespace ChainCraft.Data
{
    [CreateAssetMenu(menuName = "Scriptable Objects/ProducerConfig")]
    public class ProducerConfig : ScriptableObject
    {
        public Recipe recipe => _recipe;
        public int capacity => _capacity;

        [SerializeField] private Recipe _recipe;
        [SerializeField] private int _capacity = 10;
    }
}