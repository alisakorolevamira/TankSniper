using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Inventory;
using Sources.Scripts.Presentations.Views.Inventory;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Scripts.Infrastructure.Factories.Views.Inventory
{
    public class InventoryTankViewFactory : IInventoryTankViewFactory
    {
        public IInventoryTankView Create(int level)
        {
            InventoryTankView view = CreateView(level);

            return view;
        }
        
        private InventoryTankView CreateView(int level)
        {
            InventoryTankView view = Object.Instantiate(
                Resources.Load<InventoryTankView>(PrefabPath.InventoryTank));

            return view;
        }
    }
}