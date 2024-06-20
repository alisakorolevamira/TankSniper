using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Inventory;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Inventory;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;

namespace Sources.Scripts.Infrastructure.Services.Spawners
{
    public class InventoryTankSpawnerService : IInventoryTankSpawnerService
    {
        private readonly IInventoryTankViewFactory _viewFactory;
        
        private IReadOnlyList<InventorySlotView> _slots;

        public InventoryTankSpawnerService(IInventoryTankViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IInventoryTankView Spawn(int level, InventorySlotView inventorySlotView)
        {
            IInventoryTankView view = _viewFactory.Create(level, inventorySlotView, this);
            inventorySlotView.SetTank(view);
            
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