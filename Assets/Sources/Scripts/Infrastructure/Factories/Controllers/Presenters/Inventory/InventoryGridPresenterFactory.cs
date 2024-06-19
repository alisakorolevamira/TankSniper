using System;
using Sources.Scripts.Controllers.Presenters.Inventory;
using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;

namespace Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Inventory
{
    public class InventoryGridPresenterFactory
    {
        private readonly IInventoryTankSpawnerService _spawnerService;

        public InventoryGridPresenterFactory(IInventoryTankSpawnerService spawnerService)
        {
            _spawnerService = spawnerService ?? throw new ArgumentNullException(nameof(spawnerService));
        }
        
        public InventoryGridPresenter Create(InventoryGrid grid, IInventoryGridView view)
        {
            return new InventoryGridPresenter(grid, view, _spawnerService);
        }
    }
}