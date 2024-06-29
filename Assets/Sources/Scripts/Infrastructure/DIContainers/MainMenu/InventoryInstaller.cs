using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Inventory;
using Sources.Scripts.Infrastructure.Factories.Views.Inventory;
using Sources.Scripts.Infrastructure.Services.ObjectPool;
using Sources.Scripts.Infrastructure.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Inventory;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool.Generic;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Inventory;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.MainMenu
{
    public class InventoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IObjectPool<InventoryTankView>>().To<ObjectPool<InventoryTankView>>().AsSingle();
            
            Container.Bind<IInventoryTankViewFactory>().To<InventoryTankViewFactory>().AsSingle();
            Container.Bind<IInventoryTankSpawnerService>().To<InventoryTankSpawnerService>().AsSingle();

            Container.Bind<InventoryGridPresenterFactory>().AsSingle();
            Container.Bind<InventoryGridViewFactory>().AsSingle();

            Container.Bind<InventoryTankButtonPresenterFactory>().AsSingle();
            Container.Bind<InventoryTankButtonViewFactory>().AsSingle();
        }
    }
}