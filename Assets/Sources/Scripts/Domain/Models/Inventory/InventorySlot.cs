using System;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;
using Sources.Scripts.DomainInterfaces.Models.Inventory;

namespace Sources.Scripts.Domain.Models.Inventory
{
    public class InventorySlot : IEntity, IInventorySlot
    {
        public InventorySlot(InventorySlotDto inventorySlotDto)
        {
            Id = inventorySlotDto.Id;
            IsEmpty = inventorySlotDto.IsEmpty;
            Level = inventorySlotDto.Level;
        }
        
        public InventorySlot(
            string id,
            bool isEmpty,
            int level)
        {
            Id = id;
            IsEmpty = isEmpty;
            Level = level;
        }
        
        public bool IsEmpty { get; private set; }
        public string Id { get; }
        public int Level { get; private set; }
        public Type Type => GetType();

        public void ChangeValues(bool isEmpty, int level)
        {
            IsEmpty = isEmpty;
            Level = level;
        }
    }
}