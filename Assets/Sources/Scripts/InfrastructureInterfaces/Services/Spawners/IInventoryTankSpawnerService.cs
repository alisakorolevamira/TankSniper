using System.Collections.Generic;
using Sources.Scripts.Presentations.Views.Inventory;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners
{
    public interface IInventoryTankSpawnerService
    {
        IInventoryTankView Spawn(int level, InventorySlotView inventorySlotView);
        void Spawn(int level);
        void AddSlots(IReadOnlyList<InventorySlotView> slots);
    }
}