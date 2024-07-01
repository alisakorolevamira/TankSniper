using System.Collections.Generic;
using System.Linq;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;
using Sources.Scripts.DomainInterfaces.Models.Inventory;
using UnityEngine;

namespace Sources.Scripts.Domain.Models.Inventory
{
    public class InventoryGrid : IEntity
    {
        private readonly Vector2Int _size = new(3, 3);
        
        private Dictionary<Vector2Int, InventorySlot> _slots;
        private InventoryGridData _data = new ();
        
        public InventoryGrid(string id)
        {
            Id = id;

            _slots = new Dictionary<Vector2Int, InventorySlot>()
            {
                {new Vector2Int(0,0), new InventorySlot(true, InventoryTankConst.DefaultTankLevel)},
                {new Vector2Int(0,1), new InventorySlot(true, InventoryTankConst.DefaultTankLevel)},
                {new Vector2Int(0,2), new InventorySlot(true, InventoryTankConst.DefaultTankLevel)},
                {new Vector2Int(1,0), new InventorySlot(true, InventoryTankConst.DefaultTankLevel)},
                {new Vector2Int(1,1), new InventorySlot(false, InventoryTankConst.DefaultTankLevel)},
                {new Vector2Int(1,2), new InventorySlot(true, InventoryTankConst.DefaultTankLevel)},
                {new Vector2Int(2,0), new InventorySlot(true, InventoryTankConst.DefaultTankLevel)},
                {new Vector2Int(2,1), new InventorySlot(true, InventoryTankConst.DefaultTankLevel)},
                {new Vector2Int(2,2), new InventorySlot(true, InventoryTankConst.DefaultTankLevel)},
            };
        }

        public Dictionary<Vector2Int, InventorySlot> Slots => _slots;

        public string Id { get; }

        public void Save()
        {
            _data.Id = Id;
            _data.Slots = Slots.Values.ToList();
            
            _data.Save(Id);
        }

        public void Load()
        {
            _data = _data.Load(Id);

            _slots = new Dictionary<Vector2Int, InventorySlot>();
            
            for (int i = 0; i < _size.x; i++)
            {
                for (int j = 0; j < _size.y; j++)
                {
                    int index = i * _size.y + j;
                    InventorySlot slot = _data.Slots[index];
                    Vector2Int position = new Vector2Int(i, j);

                    _slots[position] = slot;
                }
            }
        }
    }
}