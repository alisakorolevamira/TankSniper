using Sources.Scripts.Domain.Models.Inventory;
using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Inventory
{
    public interface IInventorySlotView
    {
        Vector2Int Position { get; }
        bool IsEmpty { get; }
        int Level { get; }
        IInventoryTankView CurrentTank { get; }
        void Construct(InventorySlot slot);
    }
}