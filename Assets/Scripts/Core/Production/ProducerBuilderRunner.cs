using ChainCraft.Data;
using UnityEngine;

namespace ChainCraft.Core.Production
{
    [RequireComponent(typeof(ProducerBuilder))]
    public class ProducerBuilderRunner : MonoBehaviour
    {
        [SerializeField] private ProducerConfig _config;

        private void Awake()
        {
            var builder = GetComponent<ProducerBuilder>();
            builder.Build(_config.recipe, _config.capacity);
        }
    }
}