using System.Collections.Generic;
using Sources.Scripts.Interfaces;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Inventory
{
    public class InventoryGrid : IInventoryGrid
    {
        private Dictionary<Vector2Int, InventorySlot> _slots = new();
        private readonly Vector2Int _size = new(3, 3);
        
        public InventoryGrid(List<InventorySlot> slots)
        {
            for (int i = 0; i < _size.x; i++)
            {
                for (int j = 0; j < _size.y; j++)
                {
                    int index = i * _size.y + j;
                    InventorySlot slot = slots[index];
                    Vector2Int position = new Vector2Int(i, j);

                    _slots[position] = slot;
                }
            }
        }

        public Dictionary<Vector2Int, InventorySlot> Slots => _slots;
    }
}