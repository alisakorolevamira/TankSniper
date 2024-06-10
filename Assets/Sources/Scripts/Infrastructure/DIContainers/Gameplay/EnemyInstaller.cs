using System.Collections.Generic;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Common;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Base;
using Sources.Scripts.Infrastructure.Factories.Controllers.Presenters.Enemies.Boss;
using Sources.Scripts.Infrastructure.Factories.Views.Common;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Base;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Boss;
using Sources.Scripts.Infrastructure.Services.Enemies;
using Sources.Scripts.Infrastructure.Services.ObjectPool;
using Sources.Scripts.Infrastructure.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool.Generic;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.Presentations.Views.Enemies.Boss;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Base;
using Zenject;

namespace Sources.Scripts.Infrastructure.DIContainers.Gameplay
{
    public class EnemyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<List<IEnemyView>>().AsSingle();

            //Container.Bind<IObjectPool<EnemyView>>().To<ObjectPool<EnemyView>>().AsSingle();
            //Container.Bind<IObjectPool<BossEnemyView>>().To<ObjectPool<BossEnemyView>>().AsSingle();

            Container.Bind<IEnemySpawnerService>().To<EnemySpawnerService>().AsSingle();
            Container.Bind<IBossEnemySpawnerService>().To<BossEnemySpawnerService>().AsSingle();
            Container.Bind<IEnemyAttackService>().To<EnemyAttackService>().AsSingle();
            
            Container.Bind<HealthUITextPresenterFactory>().AsSingle();
            Container.Bind<HealthUITextViewFactory>().AsSingle();

            Container.Bind<BossEnemyPresenterFactory>().AsSingle();
            Container.Bind<IBossEnemyViewFactory>().To<BossEnemyViewFactory>().AsSingle();

            Container.Bind<EnemyHealthPresenterFactory>().AsSingle();
            Container.Bind<EnemyHealthViewFactory>().AsSingle();
            Container.Bind<EnemyPresenterFactory>().AsSingle();
            Container.Bind<IEnemyViewFactory>().To<EnemyViewFactory>().AsSingle();
        }
    }
}