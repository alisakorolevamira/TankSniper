using System;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Inventory;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;

namespace Sources.Scripts.UIFramework.Infrastructure.Commands.Buttons
{
    public class AddTankCommand : IButtonCommand
    {
        private readonly IInventoryTankSpawnerService _spawnerService;

        public AddTankCommand(IInventoryTankSpawnerService spawnerService)
        {
            _spawnerService = spawnerService ?? throw new ArgumentNullException(nameof(spawnerService));
        }
        
        public ButtonCommandId Id => ButtonCommandId.AddTank;
        
        public void Handle(IUIButton uiButton)
        {
            InventorySlotView emptySlot = _spawnerService.FindEmptySlot();

            if (emptySlot == null)
                return;
            
            
            _spawnerService.Spawn(1, emptySlot.transform.position);
        }
    }
}