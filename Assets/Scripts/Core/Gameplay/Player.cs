using ChainCraft.Core.Production;
using UnityEngine;

namespace ChainCraft.Core.Gameplay
{
    public class Player : MonoBehaviour
    {
        public Backpack backpack { get; private set; }

        public void Init(Backpack backpack)
        {
            this.backpack = backpack;
        }
    }
}
