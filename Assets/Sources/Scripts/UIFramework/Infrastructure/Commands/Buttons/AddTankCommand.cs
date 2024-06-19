using System;
using Sources.Scripts.Controllers.Presenters.Inventory;
using Sources.Scripts.Infrastructure.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.UIFramework.Domain.Commands;
using Sources.Scripts.UIFramework.InfrastructureInterfaces.Commands.Buttons;
using Sources.Scripts.UIFramework.PresentationsInterfaces.Buttons;
using UnityEngine;

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
            _spawnerService.Spawn(1);
        }
    }
}