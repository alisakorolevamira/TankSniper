using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Standing;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Enemies.Standing;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Standing;

namespace Sources.Scripts.Infrastructure.Services.Spawners
{
    public class StandingEnemySpawnerService : IStandingEnemySpawnerService
    {
        private readonly IStandingEnemyViewFactory _viewFactory;

        public StandingEnemySpawnerService(IStandingEnemyViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IStandingEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, StandingEnemyView view)
        {
            StandingEnemy enemy = new StandingEnemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.StandingDamage));
            IStandingEnemyView enemyView = _viewFactory.Create(enemy, killedEnemiesCounter, view);

            return enemyView;
        }
    }
}