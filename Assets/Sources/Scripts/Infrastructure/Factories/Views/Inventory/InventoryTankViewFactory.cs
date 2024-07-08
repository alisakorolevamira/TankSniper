using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Inventory;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Inventory;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Scripts.Infrastructure.Factories.Views.Inventory
{
    public class InventoryTankViewFactory : IInventoryTankViewFactory
    {
        public IInventoryTankView Create(
            int level,
            InventorySlotView inventorySlotView,
            IInventoryTankSpawnerService spawnerService)
        {
            InventoryTankView view = CreateView(level);
            view.SetPosition(inventorySlotView.transform.position);
            view.Construct(spawnerService,level, inventorySlotView);

            return view;
        }
        
        private InventoryTankView CreateView(int level)
        {
            InventoryTankView view = Object.Instantiate(
                Resources.Load<InventoryTankView>($"{PrefabPath.InventoryTank + level}"));

            return view;
        }
    }
}