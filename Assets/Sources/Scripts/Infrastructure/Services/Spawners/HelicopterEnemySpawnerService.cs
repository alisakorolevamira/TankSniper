using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Helicopter;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.InfrastructureInterfaces.Factories.Views.Enemies;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.Presentations.Views.Enemies.Helicopter;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;

namespace Sources.Scripts.Infrastructure.Services.Spawners
{
    public class HelicopterEnemySpawnerService : IHelicopterEnemySpawnerService
    {
        private readonly IHelicopterEnemyViewFactory _viewFactory;

        public HelicopterEnemySpawnerService(
            IHelicopterEnemyViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IHelicopterEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, HelicopterEnemyView view)
        {
            HelicopterEnemy enemy =
                new HelicopterEnemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.HelicopterDamage));
            IHelicopterEnemyView enemyView = _viewFactory.Create(enemy, killedEnemiesCounter, view);

            return enemyView;
        }
    }
}