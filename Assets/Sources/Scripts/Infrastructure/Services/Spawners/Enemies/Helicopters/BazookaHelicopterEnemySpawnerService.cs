using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Helicopters;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Helicopters;
using Sources.Scripts.Presentations.Views.Enemies.Helicopters;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.Helicopters;

namespace Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Helicopters
{
    public class BazookaHelicopterEnemySpawnerService : IBazookaHelicopterEnemySpawnerService
    {
        private readonly BazookaHelicopterEnemyViewFactory _viewFactory;

        public BazookaHelicopterEnemySpawnerService(BazookaHelicopterEnemyViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IBazookaHelicopterEnemyView Spawn(
            KilledEnemiesCounter killedEnemiesCounter,
            BazookaHelicopterEnemyView view)
        {
            Enemy enemy = new Enemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.HelicopterDamage));
            IBazookaHelicopterEnemyView enemyView = _viewFactory.Create(enemy, killedEnemiesCounter, view);

            return enemyView;
        }
    }
}