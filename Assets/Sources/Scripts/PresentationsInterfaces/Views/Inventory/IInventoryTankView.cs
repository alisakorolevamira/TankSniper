using Sources.Scripts.Controllers.Presenters.Inventory;

namespace Sources.Scripts.PresentationsInterfaces.Views.Inventory
{
    public interface IInventoryTankView : IView
    {
        int Level { get; }

        void Construct(InventoryGridPresenter presenter, int level);
    }
}