using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Enemies.Helicopter;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Helicopter;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Helicopter;
using Sources.Scripts.Presentations.Views.Enemies.Helicopter;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopter;

namespace Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Helicopter
{
    public class HelicopterEnemySpawnerService : IHelicopterEnemySpawnerService
    {
        private readonly HelicopterEnemyViewFactory _viewFactory;

        public HelicopterEnemySpawnerService(HelicopterEnemyViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IHelicopterEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, HelicopterEnemyView view)
        {
            Enemy enemy = new Enemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.HelicopterDamage));
            IHelicopterEnemyView enemyView = _viewFactory.Create(enemy, killedEnemiesCounter, view);

            return enemyView;
        }
    }
}