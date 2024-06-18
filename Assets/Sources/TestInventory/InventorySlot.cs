using System;
using JetBrains.Annotations;
using Sources.Scripts.Interfaces;

namespace Sources.Scripts
{
    public class InventorySlot : IInventorySlot
    {
        private readonly InventorySlotData _data;
        public event Action<string> ItemChanged;

        public string ItemId
        {
            get => _data.ItemId;
            set
            {
                if (_data.ItemId != value)
                {
                    _data.ItemId = value;
                    ItemChanged?.Invoke(value);
                }
            }
        }
        public bool IsEmpty => string.IsNullOrEmpty(ItemId);

        public InventorySlot(InventorySlotData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}