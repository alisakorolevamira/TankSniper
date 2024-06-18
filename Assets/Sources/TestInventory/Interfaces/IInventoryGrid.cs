using UnityEngine;

namespace Sources.Scripts.Interfaces
{
    public interface IInventoryGrid : IInventory
    {
        Vector2Int Size { get; }
        bool Has(string itemId);
        IInventorySlot[,] GetSlots();
    }
}