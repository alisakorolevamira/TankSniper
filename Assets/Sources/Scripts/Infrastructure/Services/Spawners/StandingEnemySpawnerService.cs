using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Standing;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Tank;
using Sources.Scripts.PresentationsInterfaces.Views.Spawners;

namespace Sources.Scripts.Infrastructure.Services.Spawners
{
    public class StandingEnemySpawnerService : IStandingEnemySpawnerService
    {
        private readonly IStandingEnemyViewFactory _viewFactory;

        public StandingEnemySpawnerService(
            IStandingEnemyViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IStandingEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, IEnemySpawnPoint spawnPoint)
        {
            StandingEnemy enemy = new StandingEnemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.Damage));

            IStandingEnemyView enemyView = _viewFactory.Create(enemy, killedEnemiesCounter, spawnPoint);
            
            enemyView.SetPosition(spawnPoint.Position);
            enemyView.Show();

            return enemyView;
        }
    }
}