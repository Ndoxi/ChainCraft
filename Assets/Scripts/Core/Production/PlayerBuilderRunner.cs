using ChainCraft.Core.Gameplay;
using UnityEngine;

namespace ChainCraft.Core.Production
{
    public class PlayerBuilderRunner : MonoBehaviour
    {
        [SerializeField] private int _capacity = 10;

        private void Awake()
        {
            var builder = GetComponent<PlayerBuilder>();
            builder.Build(_capacity);
        }
    }
}