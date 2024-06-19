using System;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Inventory;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;

namespace Sources.Scripts.Infrastructure.Services.Spawners
{
    public class InventoryTankSpawnerService : IInventoryTankSpawnerService
    {
        private readonly IInventoryTankViewFactory _viewFactory;

        public InventoryTankSpawnerService(IInventoryTankViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }
        
        public IInventoryTankView Spawn(int level)
        {
            IInventoryTankView view = _viewFactory.Create(level);
            
            //view.SetPosition(position);
            
            return view;
        }
    }
}