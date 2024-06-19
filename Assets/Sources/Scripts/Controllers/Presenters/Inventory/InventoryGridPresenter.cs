using System;
using System.Linq;
using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Inventory;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;

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

        public void AddTank(int level)
        {
            InventorySlotView slot = _view.Slots.FirstOrDefault(x => x.IsEmpty);

            if (slot == null)
                return;

            IInventoryTankView tankView = _spawnerService.Spawn(slot.transform.position, level);
            tankView.Construct(this, level);

            slot.SetTank(tankView);
        }
    }
}