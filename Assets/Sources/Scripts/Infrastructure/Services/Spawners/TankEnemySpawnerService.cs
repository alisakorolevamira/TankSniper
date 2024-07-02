using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Enemies.Tank;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Enemies.Base;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;

namespace Sources.Scripts.Infrastructure.Services.Spawners
{
    public class TankEnemySpawnerService : ITankEnemySpawnerService
    {
        private readonly ITankEnemyViewFactory _viewFactory;

        public TankEnemySpawnerService(
            ITankEnemyViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public ITankEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, EnemyViewBase enemyViewBase)
        {
            TankEnemy tank = new TankEnemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.TankDamage));

            ITankEnemyView tankEnemyView = _viewFactory.Create(tank, killedEnemiesCounter, enemyViewBase);

            tankEnemyView.DisableNavmeshAgent();
            //tankEnemyView.SetPosition(spawnPoint.Position);
            tankEnemyView.EnableNavmeshAgent();
            tankEnemyView.Show();

            return tankEnemyView;
        }
    }
}