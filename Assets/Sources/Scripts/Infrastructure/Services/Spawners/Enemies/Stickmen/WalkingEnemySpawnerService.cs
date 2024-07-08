using System;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Domain.Models.Enemies;
using Sources.Scripts.Domain.Models.Enemies.Base;
using Sources.Scripts.Domain.Models.Enemies.Moving;
using Sources.Scripts.Domain.Models.Gameplay;
using Sources.Scripts.Infrastructure.Factories.Views.Enemies.Moving;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners.Enemies.Stickmen;
using Sources.Scripts.Presentations.Views.Enemies.WalkingEnemy;
using Sources.Scripts.PresentationsInterfaces.Views.Enemies.MovingEnemy;

namespace Sources.Scripts.Infrastructure.Services.Spawners.Enemies.Stickmen
{
    public class WalkingEnemySpawnerService : IWalkingEnemySpawnerService
    {
        private readonly WalkingEnemyViewFactory _viewFactory;

        public WalkingEnemySpawnerService(WalkingEnemyViewFactory viewFactory)
        {
            _viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
        }

        public IWalkingEnemyView Spawn(KilledEnemiesCounter killedEnemiesCounter, WalkingEnemyView view)
        {
            Enemy enemy = new Enemy(new EnemyHealth(EnemyConst.Health), new EnemyAttacker(EnemyConst.StandingDamage));
            IWalkingEnemyView enemyView = _viewFactory.Create(enemy, killedEnemiesCounter, view);

            return enemyView;
        }
    }
}