using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Scripts.Infrastructure.Factories.Domain.Data
{
    public class InventorySlotDtoMapper : IInventorySlotDtoMapper
    {
        public InventorySlotDto MapModelToDto(InventorySlot slot)
        {
            return new InventorySlotDto()
            {
                Id = slot.Id,
                IsEmpty = slot.IsEmpty,
                Level = slot.Level
            };
        }

        public InventorySlot MapDtoToModel(InventorySlotDto inventorySlotDto) =>
            new(inventorySlotDto);
    }
}