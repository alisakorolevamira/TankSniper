using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Inventory;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Inventory;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;
using UnityEngine;

namespace Sources.Scripts.Infrastructure.Services.Spawners
{
    public class InventoryTankSpawnerService : IInventoryTankSpawnerService
    {
        private readonly IInventoryTankViewFactory _viewFactory;
        
        private List<InventorySlotView> _slots;

        public InventoryTankSpawnerService(IInventoryTankViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IInventoryTankView Spawn(int level, Vector3 position)
        {
            IInventoryTankView view = _viewFactory.Create(level);
            
            view.SetPosition(position);
            
            return view;
        }

        public void AddSlots(List<InventorySlotView> slots)
        {
            _slots = slots;
        }

        public InventorySlotView FindEmptySlot()
        {
            InventorySlotView slot = _slots.FirstOrDefault(x => x.IsEmpty);

            return slot;
        }
    }
}