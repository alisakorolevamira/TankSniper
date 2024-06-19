using UnityEngine;

namespace Sources.Scripts.Interfaces
{
    public interface IInventoryGrid
    {
        IInventorySlot[,] GetSlots();
    }
}