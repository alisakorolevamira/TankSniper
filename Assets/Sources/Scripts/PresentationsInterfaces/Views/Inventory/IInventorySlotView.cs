using UnityEngine;

namespace Sources.Scripts.PresentationsInterfaces.Views.Inventory
{
    public interface IInventorySlotView
    {
        Vector2Int Position { get; }
        bool IsEmpty { get; }
        IInventoryTankView CurrentTank { get; }
    }
}