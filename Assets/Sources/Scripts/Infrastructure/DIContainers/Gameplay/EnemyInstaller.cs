using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Enemies.Jeep;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Common;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Boss;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Helicopter;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Jeep;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Standing;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Tank;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Boss;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Helicopter;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Jeep;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Standing;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Tank;
using Sources.Scripts.Infrastructure.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<List<ITankEnemyView>>().AsSingle();

            Container.Bind<ITankEnemySpawnerService>().To<TankEnemySpawnerService>().AsSingle();
            Container.Bind<IBossEnemySpawnerService>().To<BossEnemySpawnerService>().AsSingle();
            Container.Bind<IStandingEnemySpawnerService>().To<StandingEnemySpawnerService>().AsSingle();
            Container.Bind<IHelicopterEnemySpawnerService>().To<HelicopterEnemySpawnerService>().AsSingle();
            Container.Bind<IJeepEnemySpawnerService>().To<JeepEnemySpawnerService>().AsSingle();
            
            Container.Bind<HealthUITextPresenterFactory>().AsSingle();
            Container.Bind<HealthUITextViewFactory>().AsSingle();

            Container.Bind<BossEnemyPresenterFactory>().AsSingle();
            Container.Bind<IBossEnemyViewFactory>().To<BossEnemyViewFactory>().AsSingle();

            Container.Bind<EnemyHealthPresenterFactory>().AsSingle();
            Container.Bind<EnemyHealthViewFactory>().AsSingle();
            Container.Bind<EnemyPresenterFactory>().AsSingle();
            //Container.Bind<IEnemyViewFactory>().To<EnemyViewFactory>().AsSingle();

            Container.Bind<TankPresenterFactory>().AsSingle();
            Container.Bind<ITankEnemyViewFactory>().To<TankEnemyViewFactory>().AsSingle();

            Container.Bind<StandingEnemyPresenterFactory>().AsSingle();
            Container.Bind<IStandingEnemyViewFactory>().To<StandingEnemyViewFactory>().AsSingle();

            Container.Bind<HelicopterEnemyPresenterFactory>().AsSingle();
            Container.Bind<IHelicopterEnemyViewFactory>().To<HelicopterEnemyViewFactory>().AsSingle();

            Container.Bind<JeepEnemyPresenterFactory>().AsSingle();
            Container.Bind<IJeepEnemyViewFactory>().To<JeepEnemyViewFactory>().AsSingle();
        }
    }
}