using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Inventory;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Views.Inventory
{
    public interface IInventoryTankViewFactory
    {
        IInventoryTankView Create(int level, InventorySlotView inventorySlotView, IInventoryTankSpawnerService spawnerService);
    }
}