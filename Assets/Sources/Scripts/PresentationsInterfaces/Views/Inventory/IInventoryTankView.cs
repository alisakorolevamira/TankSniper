using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Inventory;

namespace Sources.Scripts.PresentationsInterfaces.Views.Inventory
{
    public interface IInventoryTankView : IView
    {
        int Level { get; }

        void Construct(IInventoryTankSpawnerService spawnerService, int level, InventorySlotView currentPoint);
    }
}