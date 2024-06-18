using System;
using Sources.Scripts.Interfaces;

namespace Sources.Scripts
{
    public class Inventory : IInventory
    {
        public event Action<string> ItemAdded;
        public event Action<string> ItemRemoved;
    }
}