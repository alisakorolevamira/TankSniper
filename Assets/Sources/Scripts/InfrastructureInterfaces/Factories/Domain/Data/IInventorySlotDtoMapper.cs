using Sources.Scripts.Domain.Models.Data;
using Sources.Scripts.Domain.Models.Inventory;

namespace Sources.Scripts.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IInventorySlotDtoMapper
    {
        InventorySlotDto MapModelToDto(InventorySlot inventorySlot);
        InventorySlot MapDtoToModel(InventorySlotDto inventorySlotDto);
    }
}