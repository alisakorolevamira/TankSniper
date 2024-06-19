using System;

namespace Sources.Scripts.Interfaces
{
    public interface IInventorySlot
    {
        bool IsEmpty { get; }
        int Level { get; }
    }
}