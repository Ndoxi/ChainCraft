namespace ChainCraft.Core.Production
{
    public class Backpack
    {
        public readonly BackpackModel model;
        public readonly BackpackView view;

        public Backpack(BackpackModel model, BackpackView view)
        {
            this.model = model;
            this.view = view;
        }
    }
}