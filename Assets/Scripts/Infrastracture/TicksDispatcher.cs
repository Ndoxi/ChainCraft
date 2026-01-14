using System.Collections.Generic;
using UnityEngine;

namespace ChainCraft.Infrastracture
{
    public class TicksDispatcher : MonoBehaviour, ITicksDispatcher
    {
        private readonly HashSet<ITickable> _managed = new(16);

        public void Register(ITickable tickable)
        {
            _managed.Add(tickable);
        }

        public void Unregister(ITickable tickable)
        {
            _managed.Remove(tickable);
        }

        private void Update()
        {
            foreach (var tackeble in _managed)
                tackeble.Tick(Time.deltaTime);
        }
    }
}