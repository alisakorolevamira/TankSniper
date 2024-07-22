using System.Collections.Generic;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Common;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Boat;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Bosses;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Dron;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Helicopters;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Jeep;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Standing;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Tanks;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Walking;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Boat;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Bosses;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Dron;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Helicopters;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Jeep;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Standing;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Tanks;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Walking;
using Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Boat;
using Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Bosses;
using Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Dron;
using Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Helicopters;
using Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Jeep;
using Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Stickmen;
using Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Tanks;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Boat;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Bosses;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Dron;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Helicopters;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Jeep;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Stickmen;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Tanks;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<List<IEnemyViewBase>>().AsSingle();

            Container.Bind<ITankEnemySpawnerService>().To<TankEnemySpawnerService>().AsSingle();
            Container.Bind<IStandingEnemySpawnerService>().To<StandingEnemySpawnerService>().AsSingle();
            Container.Bind<IBazookaHelicopterEnemySpawnerService>().To<BazookaHelicopterEnemySpawnerService>().AsSingle();
            Container.Bind<IJeepEnemySpawnerService>().To<JeepEnemySpawnerService>().AsSingle();
            Container.Bind<IDronEnemySpawnerService>().To<DronEnemySpawnerService>().AsSingle();
            Container.Bind<IWalkingEnemySpawnerService>().To<WalkingEnemySpawnerService>().AsSingle();
            Container.Bind<IBoatEnemySpawnerService>().To<BoatEnemySpawnerService>().AsSingle();
            Container.Bind<IStandingTankEnemySpawnerService>().To<StandingTankEnemySpawnerService>().AsSingle();
            Container.Bind<IHelicopterEnemySpawnerService>().To<HelicopterEnemySpawnerService>().AsSingle();
            Container.Bind<IRobotBossEnemySpawnerService>().To<RobotRobotBossEnemySpawnerService>().AsSingle();
            Container.Bind<IBoatBossEnemySpawnerService>().To<BoatBossEnemySpawnerService>().AsSingle();
            Container.Bind<IHelicopterBossEnemySpawnerService>().To<HelicopterBossEnemySpawnerService>().AsSingle();
            
            Container.Bind<HealthUITextPresenterFactory>().AsSingle();
            Container.Bind<HealthUITextViewFactory>().AsSingle();

            Container.Bind<EnemyHealthPresenterFactory>().AsSingle();
            Container.Bind<EnemyHealthViewFactory>().AsSingle();

            Container.Bind<TankPresenterFactory>().AsSingle();
            Container.Bind<TankEnemyViewFactory>().AsSingle();
            
            Container.Bind<RobotBossEnemyPresenterFactory>().AsSingle();
            Container.Bind<RobotBossEnemyViewFactory>().AsSingle();

            Container.Bind<StandingEnemyPresenterFactory>().AsSingle();
            Container.Bind<StandingEnemyViewFactory>().AsSingle();

            Container.Bind<BazookaHelicopterEnemyPresenterFactory>().AsSingle();
            Container.Bind<BazookaHelicopterEnemyViewFactory>().AsSingle();

            Container.Bind<JeepEnemyPresenterFactory>().AsSingle();
            Container.Bind<JeepEnemyViewFactory>().AsSingle();

            Container.Bind<DronEnemyPresenterFactory>().AsSingle();
            Container.Bind<DronEnemyViewFactory>().AsSingle();
            
            Container.Bind<WalkingEnemyPresenterFactory>().AsSingle();
            Container.Bind<WalkingEnemyViewFactory>().AsSingle();
            
            Container.Bind<StandingTankPresenterFactory>().AsSingle();
            Container.Bind<StandingTankEnemyViewFactory>().AsSingle();
            
            Container.Bind<HelicopterEnemyPresenterFactory>().AsSingle();
            Container.Bind<HelicopterEnemyViewFactory>().AsSingle();
            
            Container.Bind<BoatBossEnemyPresenterFactory>().AsSingle();
            Container.Bind<BoatBossEnemyViewFactory>().AsSingle();
            
            Container.Bind<BoatEnemyPresenterFactory>().AsSingle();
            Container.Bind<BoatEnemyViewFactory>().AsSingle();
            
            Container.Bind<HelicopterBossEnemyPresenterFactory>().AsSingle();
            Container.Bind<HelicopterBossEnemyViewFactory>().AsSingle();
        }
    }
}