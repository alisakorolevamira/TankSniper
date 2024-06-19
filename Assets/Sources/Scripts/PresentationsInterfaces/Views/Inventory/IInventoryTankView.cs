using Sources.Scripts.Controllers.Presenters.Inventory;
using Sources.Scripts.Infrastructure.Services.Spawners;

namespace Sources.Scripts.PresentationsInterfaces.Views.Inventory
{
    public interface IInventoryTankView : IView
    {
        int Level { get; }

        void Construct(InventoryTankSpawnerService spawnerService, int level);
    }
}