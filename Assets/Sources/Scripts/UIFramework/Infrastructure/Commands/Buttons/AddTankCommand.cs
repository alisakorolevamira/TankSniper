using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;

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
        
        public void Handle() => 
            _spawnerService.Spawn(InventoryConst.DefaultTankLevel);
    }
}