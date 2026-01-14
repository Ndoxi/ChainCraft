namespace ChainCraft.Core.Production
{
    public class Warehouse
    {
        public readonly WarehouseModel model;
        public readonly WarehouseView view;

        public Warehouse(WarehouseModel model, WarehouseView view)
        {
            this.model = model;
            this.view = view;
        }
    }
}