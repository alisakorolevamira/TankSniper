using System;
using System.Linq;
using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;
using UnityEngine;

namespace Sources.Scripts.Controllers.Presenters.Inventory
{
    public class InventoryGridPresenter : PresenterBase
    {
        private readonly InventoryGrid _grid;
        private readonly IInventoryGridView _view;
        private readonly IInventoryTankSpawnerService _spawnerService;

        public InventoryGridPresenter(
            InventoryGrid grid,
            IInventoryGridView view,
            IInventoryTankSpawnerService spawnerService)
        {
            _grid = grid ?? throw new ArgumentNullException(nameof(grid));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _spawnerService = spawnerService ?? throw new ArgumentNullException(nameof(spawnerService));
        }

        public override void Enable() => 
            Fill();

        private void Fill()
        {
            foreach (var slotView in _view.Slots)
            {
               var slot =
                   _grid.Slots.First(slot => slotView.Position == slot.Key);
               slotView.Construct(slot.Value);
               
               if (slotView.IsEmpty == false) 
                   _spawnerService.Spawn(slotView.Level, slotView);
            }
        }
    }
}