using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Weapons;
using Sources.Scripts.Infrastructure.Factories.Views.Bullets;
using Sources.Scripts.Infrastructure.Factories.Views.Weapons;
using Sources.Scripts.Infrastructure.Services.ObjectPool;
using Sources.Scripts.Infrastructure.Services.Spawners;
using Sources.Scripts.Infrastructure.Services.Weapons;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Bullets;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool.Generic;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.Weapons;
using Sources.Scripts.Presentations.Views.Bullets;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Gameplay
{
    public class WeaponInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IObjectPool<BulletView>>().To<ObjectPool<BulletView>>().AsSingle();
            
            Container.Bind<IBulletSpawnService>().To<BulletSpawnService>().AsSingle();
            
            Container.Bind<WeaponPresenterFactory>().AsSingle();
            Container.Bind<WeaponViewFactory>().AsSingle();

            Container.Bind<IBulletViewFactory>().To<BulletViewFactory>().AsSingle();

            Container.Bind<ReloadWeaponPresenterFactory>().AsSingle();
            Container.Bind<ReloadWeaponViewFactory>().AsSingle();

            Container.Bind<IReloadWeaponService>().To<ReloadWeaponService>().AsSingle();
        }
    }
}