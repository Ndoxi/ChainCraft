using System;
using UnityEngine;

namespace ChainCraft.Core.Gameplay
{
    public class InteractableZone : MonoBehaviour
    {
        public event Action<Player> entered;
        public event Action<Player> exited;
        public event Action<Player> onStay;

        private void OnTriggerEnter(Collider other)
        {
            if (TryGetPlayer(other, out var player))
                entered?.Invoke(player);
        }

        private void OnTriggerExit(Collider other)
        {
            if (TryGetPlayer(other, out var player))
                exited?.Invoke(player);
        }

        private void OnTriggerStay(Collider other)
        {
            if (TryGetPlayer(other, out var player))
                onStay?.Invoke(player);
        }

        private bool TryGetPlayer(Collider collider, out Player player)
        {
            if (collider.attachedRigidbody != null 
                && collider.attachedRigidbody.TryGetComponent(out player))
            {
                return true;
            }

            player = null;
            return false;
        }
    }
}
