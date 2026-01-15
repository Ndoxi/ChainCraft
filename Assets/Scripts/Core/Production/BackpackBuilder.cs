using UnityEngine;

namespace ChainCraft.Core.Production
{
    [RequireComponent(typeof(BackpackView))]
    public class BackpackBuilder : MonoBehaviour
    {
        public Backpack Build(int capacity)
        {
            var model = new BackpackModel(capacity);
            var view = GetComponent<BackpackView>();
            view.Init(model);

            return new Backpack(model, view);
        }
    }
}