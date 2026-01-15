using ChainCraft.Core.Production;
using UnityEngine;

namespace ChainCraft.Core.Gameplay
{
    public class PlayerBuilder : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private BackpackBuilder _backpackBuilder;

        public void Build(int capacity)
        {
            var backpack = _backpackBuilder.Build(capacity);
            _player.Init(backpack);
        }
    }
}
