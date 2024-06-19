using System;
using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.DomainInterfaces.Models.Entities;
using Sources.Scripts.Interfaces;

namespace Sources.Scripts.Domain.Models.Inventory
{
    public class InventorySlot : IEntity, IInventorySlot
    {
        public InventorySlot(InventorySlotDto inventorySlotDto)
        {
            Id = inventorySlotDto.Id;
            IsEmpty = inventorySlotDto.IsEmpty;
        }
        
        public InventorySlot(
            string id,
            bool isEmpty)
        {
            Id = id;
            IsEmpty = isEmpty;
        }
        
        public bool IsEmpty { get; private set; }
        public string Id { get; }
        public Type Type => GetType();
    }
}