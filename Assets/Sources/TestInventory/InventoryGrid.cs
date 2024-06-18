using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Sources.Scripts.Interfaces;
using UnityEngine;

namespace Sources.Scripts
{
    public class InventoryGrid : IInventoryGrid
    {
        private readonly InventoryGridData _data;
        private readonly Dictionary<Vector2Int, InventorySlot> _slotsMap = new ();

        public event Action<string> ItemAdded;
        public event Action<string> ItemRemoved;

        public InventoryGrid(InventoryGridData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            var size = data.Size;

            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    int index = i * size.y + j;
                    var slotData = data.Slots[index];
                    var slot = new InventorySlot(slotData);
                    var position = new Vector2Int(i, j);

                    _slotsMap[position] = slot;
                }
            }
        }

        public Vector2Int Size => _data.Size;

        public IInventorySlot[,] GetSlots ()
        {
            var array = new IInventorySlot[Size.x, Size.y];
            
            for (int i = 0; i < Size.x; i++)
            {
                for (int j = 0; j < Size.y; j++)
                {
                    var position = new Vector2Int(i, j);

                    array[i, j] = _slotsMap[position];
                }
            }

            return array;
        }
        
        public bool Has(string itemId)
        {
            var slots = _data.Slots;

            return slots.Any(slot => slot.ItemId == itemId);
        }

        public void AddItem(string itemId)
        {
            var slot = _slotsMap.FirstOrDefault(x => x.Value.IsEmpty);

            if (slot.Value == null)
                return;

            slot.Value.ItemId = itemId;
        }

        public void AddItem(Vector2Int slotPosition, string itemId)
        {
            var slot = _slotsMap[slotPosition];

            if (slot.IsEmpty)
            {
                slot.ItemId = itemId;
            }
        }

        public void RemoveItem(Vector2Int slotPosition, string itemId)
        {
            var slot = _slotsMap[slotPosition];

            if (slot.IsEmpty || slot.ItemId != itemId)
                return;

            slot.ItemId = null;
        }
    }
}