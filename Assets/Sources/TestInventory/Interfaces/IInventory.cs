using System;

namespace Sources.Scripts.Interfaces
{
    public interface IInventory
    {
        event Action<string> ItemAdded;
        event Action<string> ItemRemoved;
    }
}