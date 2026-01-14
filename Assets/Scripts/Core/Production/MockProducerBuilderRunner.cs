using ChainCraft.Data;
using UnityEngine;

namespace ChainCraft.Core.Production
{
    public class MockProducerBuilderRunner : MonoBehaviour
    {
        [SerializeField] private Recipe _recipe;
        [SerializeField] private int _capacity = 10;

        private void Awake()
        {
            var builder = GetComponent<ProducerBuilder>();
            builder.Build(_recipe, _capacity);
        }
    }
}