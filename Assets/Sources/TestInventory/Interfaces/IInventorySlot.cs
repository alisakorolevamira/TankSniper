using System;

namespace Sources.Scripts.Interfaces
{
    public interface IInventorySlot
    {
        event Action<string> ItemChanged;
        
        string ItemId { get; }
        bool IsEmpty { get; }
    }
}