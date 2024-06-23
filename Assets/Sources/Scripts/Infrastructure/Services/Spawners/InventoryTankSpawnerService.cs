using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Inventory;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.UpgradeServices;
using Sources.Scripts.Presentations.Views.Inventory;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;

namespace Sources.Scripts.Infrastructure.Services.Spawners
{
    public class InventoryTankSpawnerService : IInventoryTankSpawnerService
    {
        private readonly IInventoryTankViewFactory _viewFactory;
        private readonly IUpgradeService _upgradeService;

        private IReadOnlyList<InventorySlotView> _slots;

        public InventoryTankSpawnerService(IInventoryTankViewFactory viewFactory, IUpgradeService upgradeService)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
        }

        public IInventoryTankView Spawn(int level, InventorySlotView inventorySlotView)
        {
            IInventoryTankView view = _viewFactory.Create(level, inventorySlotView, this);
            
            inventorySlotView.SetTank(view);
            _upgradeService.CheckLevel(level);
            
            return view;
        }

        public IInventoryTankView Spawn(int level)
        {
            InventorySlotView emptySlot = FindEmptySlot();

            if (emptySlot == null)
                return null;

            IInventoryTankView view = Spawn(level, emptySlot);

            return view;
        }

        public void AddSlots(IReadOnlyList<InventorySlotView> slots) => 
            _slots = slots;

        private InventorySlotView FindEmptySlot()
        {
            InventorySlotView slot = _slots.FirstOrDefault(x => x.IsEmpty);

            return slot;
        }
    }
}